using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using recipe_api.Infrastructure;
using recipe_api.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using recipe_domain;
using Recipe.Application.DTO;

namespace recipe_api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController: Controller
    {
        private readonly IOptions<AuthOptions> authOptions;
        private readonly IUserRepository userRepository;
        public AccountController(IOptions<AuthOptions> auth, IUserRepository _userRepository)
        {
            authOptions = auth;
            userRepository = _userRepository;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel request)
        {
            var user = await userRepository.AuthenticateUser(request.Login, request.Password);
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
        public async Task<IActionResult> Register([FromBody]UserDto user)
		{
            bool r = await userRepository.RegisterUser(user.Login, user.Name, user.Password);
            if (!r)
			{
                return Ok();
			}
            var authUser = await userRepository.AuthenticateUser(user.Login, user.Password);
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

        private string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;

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