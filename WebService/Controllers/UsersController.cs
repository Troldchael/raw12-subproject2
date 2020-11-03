using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _dataService.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UsersDto>>(users));
        }


    }


}
