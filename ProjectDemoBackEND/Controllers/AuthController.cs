using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectDemoBackEND.Data.DomainClasses;
using ProjectDemoBackEND.Data.IRepositories;
using ProjectDemoBackEND.DTOs;

namespace ProjectDemoBackEND.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase {
        private readonly IUserAuthRepo _repo;
        private readonly IConfiguration _config;

        public AuthController (IUserAuthRepo repo, IConfiguration config) {
            this._config = config;
            this._repo = repo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO userDto)
        {
            var userCheck = await _repo.UserExits(userDto.UserName);
            
            if (userCheck)
                return BadRequest("User name already exists");

            var userToCreate = new User
            {
                UserName = userDto.UserName
            };

            var addUser = await _repo.Register(userToCreate, userDto.Password);

            if (addUser)
            {
                await _repo.Save();          
                return StatusCode(201);
            }
            else
            {
                return BadRequest("Something went wrong!");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userDto)
        {
            var userFromDB = await _repo.Login(userDto.UserName, userDto.Password);

            if (userFromDB == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromDB.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userFromDB.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creden = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creden
            };
 
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }

    }
}