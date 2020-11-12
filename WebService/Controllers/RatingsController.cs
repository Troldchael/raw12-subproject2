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
   /* [ApiController]
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public RatingsController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetRatings))]
        public IActionResult GetRatings(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var searches = _dataService.GetRatingInfo(page, pageSize);

            var result = CreateResult(page, pageSize, searches);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetRating))]
        public IActionResult GetRating(int id)
        {
            var ratings = _dataService.GetRating(id);
            if (ratings == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<RatingElementDto>(ratings);
            dto.Url = Url.Link(nameof(GetRating), new { id });

            return Ok(dto);
        }

        private RatingElementDto CreateRatingElementDto(RatingHistory ratings)
        {

            var dto = _mapper.Map<RatingElementDto>(ratings);

            dto.Url = Url.Link(nameof(GetRating), new { ratings.UserId });

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
                prev = Url.Link(nameof(GetRating), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetRating), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetRating), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<RatingHistory> ratings)
        {
            var items = ratings.Select(CreateRatingElementDto);
            
            var count = _dataService.NumberOfRatings();

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
*/
    }



