using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

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

            _dataService.CreateUser(dto.Username, dto.Password, salt);




            return Ok(); 
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            return Ok();
        }
    }
}
