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

        [HttpGet(Name = nameof(GetActors))]
        public IActionResult GetActors(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var actors = _dataService.GetActorInfo(page, pageSize);

            var result = CreateResult(page, pageSize, actors);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetActor))]
        public IActionResult GetActor(string id)
        {
            var actors = _dataService.GetActor(id);
            if (actors == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<SearchElementDto>(actors);
            dto.Url = Url.Link(nameof(GetActor), new { id });

            return Ok(dto);
        }

        private ActorElementDto CreateActorElementDto(Actors actors)
        {
            var dto = _mapper.Map<ActorElementDto>(actors);
            dto.Url = Url.Link(nameof(GetActor), new { id = actors.Nconst });

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetActor), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetActor), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetActor), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Actors> actors)
        {
            var items = actors.Select(CreateActorElementDto);

            var count = _dataService.NumberOfSearches();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }


    }


}
