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
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;

        public GenreController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = _dataService.GetGenres();
            return Ok(_mapper.Map<IEnumerable<Genres>>(genres));

        }

    }


}
