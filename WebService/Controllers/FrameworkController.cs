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
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 10;


        public UsersController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var users = _dataService.GetUserInfo(page, pageSize);

            var result = CreateResult(page, pageSize, users);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetUser))]
        public IActionResult GetUser(int id)
        {
            var users = _dataService.GetUser(id);
            if (users == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<UserElementDto>(users);
            dto.Url = Url.Link(nameof(GetUser), new { id });

            return Ok(dto);
        }


        [HttpPost]
        public IActionResult CreateUsers(UserForCreationOrUpdateDto userOrUpdateDto)
        {
            var users = _mapper.Map<Users>(userOrUpdateDto);

            _dataService.CreateUser(users);

            return Created("", users);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserForCreationOrUpdateDto userOrUpdateDto)
        {
            var users = _mapper.Map<Users>(userOrUpdateDto);

            users.UserId = id; //this fixes the id null value

            if (!_dataService.UpdateUser(users))
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!_dataService.DeleteUser(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private UserElementDto CreateUserElementDto(Users users)
        {
            var dto = _mapper.Map<UserElementDto>(users);

            dto.Url = Url.Link(nameof(GetUser), new {id = users.UserId});

            return dto;
        }

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetUsers), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetUsers), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetUsers), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Users> users)
        {
            var items = users.Select(CreateUserElementDto);

            var count = _dataService.NumberOfUsers();

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

        [HttpPost]
        public IActionResult CreateSearch(SearchForCreationOrUpdateDto searchUpdateDto)
        {
            var searches = _mapper.Map<SearchHistory>(searchUpdateDto);

            _dataService.CreateSearch(searches);

            return Created("", searches);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSearch(int id, SearchForCreationOrUpdateDto searchUpdateDto)
        {
            var searches = _mapper.Map<SearchHistory>(searchUpdateDto);

            searches.UserId = id; //this fixes the id null value

            if (!_dataService.UpdateSearch(searches))
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSearch(int id)
        {
            if (!_dataService.DeleteSearch(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        private SearchElementDto CreateSearchElementDto(SearchHistory searches)
        {

            var dto = _mapper.Map<SearchElementDto>(searches);

            dto.Url = Url.Link(nameof(GetSearch), new { id = searches.UserId });

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
                prev = Url.Link(nameof(GetSearches), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetSearches), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetSearches), new { page, pageSize });

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

    [ApiController]
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

            dto.Url = Url.Link(nameof(GetRating), new { id = ratings.UserId });

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
                prev = Url.Link(nameof(GetRatings), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetRatings), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetRatings), new { page, pageSize });

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

    }

    [ApiController]
    [Route("api/titlebookings")]
    public class TitleBookController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;


        public TitleBookController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetTBookings))]
        public IActionResult GetTBookings(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var tbookings = _dataService.GetTBookInfo(page, pageSize);

            var result = CreateResult(page, pageSize, tbookings);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetTBooking))]
        public IActionResult GetTBooking(int id)
        {
            var tbookings = _dataService.GetTBooking(id);
            if (tbookings == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<TBookElementDto>(tbookings);
            dto.Url = Url.Link(nameof(GetTBooking), new { id });

            return Ok(dto);
        }

        private TBookElementDto CreateTBookElementDto(TitleBookmarking tbookings)
        {

            var dto = _mapper.Map<TBookElementDto>(tbookings);
            dto.Url = Url.Link(nameof(GetTBooking), new { tbookings.UserId });

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
                prev = Url.Link(nameof(GetTBookings), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetTBookings), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetTBookings), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<TitleBookmarking> tbookings)
        {
            var items = tbookings.Select(CreateTBookElementDto);

            var count = _dataService.NumberOfTbookings();

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

    [ApiController]
    [Route("api/actorbookings")]
    public class ActorBookController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;
        public ActorBookController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetABookings))]
        public IActionResult GetABookings(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var abookings = _dataService.GetABookInfo(page, pageSize);

            var result = CreateResult(page, pageSize, abookings);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetABooking))]
        public IActionResult GetABooking(int id)
        {
            var abookings = _dataService.GetABooking(id);
            if (abookings == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ABookElementDto>(abookings);
            dto.Url = Url.Link(nameof(GetABooking), new { id });

            return Ok(dto);
        }

        private ABookElementDto createABookElementDto(ActorBookmarking abookings)
        {

            var dto = _mapper.Map<ABookElementDto>(abookings);

            dto.Url = Url.Link(nameof(GetABooking), new { abookings.UserId });

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
                prev = Url.Link(nameof(GetABookings), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetABookings), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetABookings), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<ActorBookmarking> abookings)
        {
            var items = abookings.Select(createABookElementDto);

            var count = _dataService.NumberOfAbookings();

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
