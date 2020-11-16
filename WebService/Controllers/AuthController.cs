using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace WebService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IDataService _dataService;

        public AuthController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_dataService.GetUserName(dto.Username) != null)
            {
                return BadRequest();
            }

            int passwordSize = 256;
            var salt = PasswordService.PasswordService.GenerateSalt(passwordSize);
            var pwd = PasswordService.PasswordService.HashPassword(dto.Password, salt, passwordSize);

            _dataService.CreateUser(dto.Username, dto.Email,  pwd, salt);


            return CreatedAtRoute(null, new { dto.Username}); 
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _dataService.GetUserName(dto.Username);
            if (user == null)
            {
                return BadRequest();
            }
            int passwordSize = 256;
            string secret = "27f7e5275ea0d7b09602c5381f78769f9cc273e7f7af1780a68c2ca84b388b50";

            var password = PasswordService.PasswordService.HashPassword(dto.Password, user.Salt, passwordSize);

            if(password != user.Password)
            {
                return BadRequest();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secret);


            var tokenDesription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.Now.AddSeconds(45), 
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDesription);
            var token = tokenHandler.WriteToken(securityToken);


            return Ok(new { dto.Username, token});
        }
    }
}
