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
//UNITOFWORK
//include
namespace recipe_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IUserRepository _userRepository;
        private readonly IUserDtoBuilder _userDtoBuilder;
        private readonly IUserDomainBuilder _userDomainBuilder;
        public AccountController(
            IOptions<AuthOptions> auth,
            IUserRepository userRepository,
            IUserDtoBuilder userDtoBuilder,
            IUserDomainBuilder userDomainBuilder
            )
        {
            _authOptions = auth;
            _userRepository = userRepository;
            _userDtoBuilder = userDtoBuilder;
            _userDomainBuilder = userDomainBuilder;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _userRepository.AuthenticateUser(request.Login, request.Password);
            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(
                    new
                    {
                        access_token = token,
                        name = user.Name
                    }
                );
            }
            return Unauthorized();
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            bool isRegistered = await _userRepository.RegisterUser(user.Login, user.Name, user.Password);
            if (!isRegistered)
            {
                return BadRequest();
            }
            var authUser = await _userRepository.AuthenticateUser(user.Login, user.Password);
            if (authUser != null)
            {
                var token = GenerateJWT(authUser);
                return Ok(
                    new
                    {
                        access_token = token,
                        name = authUser.Name
                    }
                );
            }
            return Unauthorized();
        }

        [Route("getUser/{userId:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(int userId)
        {
            UserDto user = await _userDtoBuilder.CreateUserDto(userId);
            if (user != null)
			{
                return Ok(
                    user
                ); 
			}
            return Unauthorized(userId);
        }

        [Route("editUser")]
        [HttpPost]
        public async Task<IActionResult> EditUser([FromBody]UserDto userDto)
		{
            User user = _userDomainBuilder.CreateUser(userDto);
            if (user != null)
            {
                await _userRepository.EditUser(user);
                return Ok();
            }

            return BadRequest();
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