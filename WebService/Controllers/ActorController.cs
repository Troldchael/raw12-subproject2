using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;

        public ActorController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            var name = _dataService.GetActors();
            return Ok(_mapper.Map<IEnumerable<Actors>>(name));

        }

    }


}
