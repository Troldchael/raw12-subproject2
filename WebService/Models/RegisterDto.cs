using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Models
{
    public class RegisterDto 
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
