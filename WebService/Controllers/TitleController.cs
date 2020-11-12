using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class TitleController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;

        public TitleController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDetails()
        {
            var title = _dataService.GetDetails();
            return Ok(_mapper.Map<IEnumerable<Details>>(title));

        }

    }


}
