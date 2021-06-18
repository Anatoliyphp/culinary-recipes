using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recipe_api.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using recipe_domain;
using recipe_api.Account.Builders;
using Application;
using recipe_infrastructure.UoW;
using Microsoft.Extensions.Logging;

namespace recipe_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUserDtoBuilder _userDtoBuilder;
        private readonly IUserDomainBuilder _userDomainBuilder;
        private readonly UnitOfWork _unitOfWork;
        public AccountController(
            IOptions<AuthOptions> auth,
            IUserRepository userRepository,
            IUserDtoBuilder userDtoBuilder,
            IUserDomainBuilder userDomainBuilder,
            UnitOfWork unitOfWork,
            ILogger<AccountController> logger
            )
        {
            _authOptions = auth;
            _userRepository = userRepository;
            _userDtoBuilder = userDtoBuilder;
            _userDomainBuilder = userDomainBuilder;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");
            _logger.LogInformation($"Searching user with login: {request.Login}");
            var user = await _userRepository.AuthenticateUser(request.Login, request.Password);
            if (user == null)
            {
                _logger.LogWarning($"Wrong fields for login");
                return Unauthorized();
            }

            _logger.LogInformation("User found");
            var token = GenerateJWT(user);
            return Ok(
                new
                {
                    access_token = token,
                    name = user.Name,
                    id = user.Id
                }
            );
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");

            _logger.LogInformation($"Trying to create user with login: {user.Login}");
            bool isRegistered = await _userRepository.RegisterUser(user.Login, user.Name, user.Password);
            if (!isRegistered)
            {
                _logger.LogError($"Failed to create user");
                return BadRequest($"Can't register user with login: {user.Login}");
            }
            await _unitOfWork.Save();

            _logger.LogInformation("User created, authenticating...");
            var authUser = await _userRepository.AuthenticateUser(user.Login, user.Password);
            if (authUser == null)
            {
                _logger.LogError($"New user authentication was failed");
                return Unauthorized();
            }

            _logger.LogInformation($" New user was authenticated");
            var token = GenerateJWT(authUser);
            return Ok(
                new
                {
                    access_token = token,
                    name = authUser.Name,
                    id = authUser.Id
                }
            );
        }

        [Route("getUser/{userId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int userId)
        {
            _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");
            _logger.LogInformation($"Searching user with id: {userId}...");
            UserDto user = await _userDtoBuilder.CreateUserDto(userId);
            if (user == null)
			{
                _logger.LogWarning($"User with id: {userId} not found");
                return Unauthorized();
            }

            _logger.LogInformation("User was found");
            return Ok(
                user
            );
        }

        [Route("editUser")]
        [HttpPost]
        public async Task<IActionResult> EditUser([FromBody]UserDto userDto)
		{
            _logger.LogInformation($"Requested path: {HttpContext.Request.Path}");
            _logger.LogInformation("Creating user from request");
            User user = _userDomainBuilder.CreateUser(userDto);
            if (user == null)
            {
                _logger.LogError($"Failed to edit user with login: {userDto.Login}");
                return BadRequest();
            }

            _userRepository.EditUser(user);
            await _unitOfWork.Save();

            _logger.LogInformation($"User with id: {user.Id} was edited");
            return Ok();
		}

        private string GenerateJWT(User user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("login", user.Login.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name)
            };

            var token = new JwtSecurityToken(authParams.Issuer,
            authParams.Audience,
            claims,
            expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}