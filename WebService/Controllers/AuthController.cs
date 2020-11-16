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
using Microsoft.Extensions.Configuration;

namespace WebService.Controllers
{
    /*
     * write [Authorization] over whatever needs authorization to be viewed or done
     */

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IConfiguration _configuration;

        public AuthController(IDataService dataService, IConfiguration configuration)
        {
            _dataService = dataService;
            _configuration = configuration;

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_dataService.GetUserName(dto.Username) != null)
            {
                return BadRequest();
            }

            int.TryParse(_configuration.GetSection("Auth: PasswordSize").Value, out int passwordSize);

            if (passwordSize == 0)
            {
                throw new ArgumentException("No password size");
            }
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

            int.TryParse(_configuration.GetSection("Auth: PasswordSize").Value, out int passwordSize);

            if (passwordSize == 0)
            {
                throw new ArgumentException("No password size");
            }
            string secret = _configuration.GetSection("Auth: secret").Value;

            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentException("No secret");
            }

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
