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
    [Route("api/rating")]
    public class RatingsController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;

        public RatingsController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetRatings()
        {
            var rating = _dataService.GetRatings();

            return Ok(_mapper.Map<IList<Ratings>>(rating.ToList()));

        }

    }


}