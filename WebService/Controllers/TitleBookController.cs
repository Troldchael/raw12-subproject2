using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.Framework;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/searches")]
    public class SearchController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;


        public SearchController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetSearches))]
        public IActionResult GetSearches(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var searches = _dataService.GetSearchInfo(page, pageSize);

            var result = CreateResult(page, pageSize, searches);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetSearch))]
        public IActionResult GetSearch(int id)
        {
            var searches = _dataService.GetSearch(id);
            if (searches == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<SearchElementDto>(searches);
            dto.Url = Url.Link(nameof(GetSearch), new { id });

            return Ok(dto);
        }

        private SearchElementDto CreateSearchElementDto(SearchHistory searches)
        {

            var dto = _mapper.Map<SearchElementDto>(searches);

            dto.Url = Url.Link(nameof(GetSearch), new { searches.UserId });

            //dto.Url = "2";

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
                prev = Url.Link(nameof(GetSearch), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetSearch), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetSearch), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<SearchHistory> searches)
        {
            var items = searches.Select(CreateSearchElementDto);

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
