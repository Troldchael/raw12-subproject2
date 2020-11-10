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
using WebService.Models.Profiles;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/actors")]


    public class ActorController : ControllerBase

    {
        IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;
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

        [HttpGet("{id}", Name = nameof(GetActor))]
        public IActionResult GetActor(string id)
        {
            var actors = _dataService.GetActor(id);
            if (actors == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ActorElementDto>(actors);
            dto.Url = Url.Link(nameof(GetActors), new {id});

            return Ok(dto);
        }

        /*private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pagesize, int count);
        {
            string prev = null;

            if (page > 0 )
            {
                prev=Url.Link(nameoff(GetActors,new { page= page-1, pageSize});

            }*/
}


}
