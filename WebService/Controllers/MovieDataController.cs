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

            var dto = _mapper.Map<ActorDto>(actors);
            dto.Url = Url.Link(nameof(GetActor), new { id });

            return Ok(dto);
        }

        private ActorDto CreateActorElementDto(Actors actors)
        {
            var dto = _mapper.Map<ActorDto>(actors);
            dto.Url = Url.Link(nameof(GetActor), new { id = actors.Nconst.Trim() }); //trim to fix id whitespace in urls

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
                prev = Url.Link(nameof(GetActors), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetActors), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetActors), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Actors> actors)
        {
            var items = actors.Select(CreateActorElementDto);

            var count = _dataService.NumberOfActors();

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
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public MovieController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetMovies))]
        public IActionResult GetMovies(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var movies = _dataService.GetMovieInfo(page, pageSize);

            var result = CreateResult(page, pageSize, movies);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetMovie))]
        public IActionResult GetMovie(string id)
        {
            var movies = _dataService.GetMovie(id);
            if (movies == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<MovieDto>(movies);
            dto.Url = Url.Link(nameof(GetMovie), new { id });

            return Ok(dto);
        }

        private MovieDto CreateMovieElementDto(Movies movies)
        {
            var dto = _mapper.Map<MovieDto>(movies);
            dto.Url = Url.Link(nameof(GetMovie), new { id = movies.TitleId.Trim() }); //trim to fix id whitespace in urls

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
                prev = Url.Link(nameof(GetMovies), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetMovies), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetMovies), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Movies> movies)
        {
            var items = movies.Select(CreateMovieElementDto);

            var count = _dataService.NumberOfMovies();

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
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public GenreController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetGenres))]
        public IActionResult GetGenres(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var genres = _dataService.GetGenreInfo(page, pageSize);

            var result = CreateResult(page, pageSize, genres);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetGenre))]
        public IActionResult GetGenre(string id)
        {
            var genres = _dataService.GetGenre(id);
            if (genres == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<GenreDto>(genres);
            dto.Url = Url.Link(nameof(GetGenre), new { id });

            return Ok(dto);
        }

        private GenreDto CreateGenreElementDto(Genres genres)
        {
            var dto = _mapper.Map<GenreDto>(genres);
            dto.Url = Url.Link(nameof(GetGenre), new { id = genres.TitleId.Trim() }); //trim to fix id whitespace in urls

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
                prev = Url.Link(nameof(GetGenres), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetGenres), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetGenres), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Genres> genres)
        {
            var items = genres.Select(CreateGenreElementDto);

            var count = _dataService.NumberOfGenres();

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
    [Route("api/details")]
    public class DetailController : ControllerBase
    {
        IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public DetailController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetDetails))]
        public IActionResult GetDetails(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var details = _dataService.GetDetailInfo(page, pageSize);

            var result = CreateResult(page, pageSize, details);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetDetail))]
        public IActionResult GetDetail(string id)
        {
            var details = _dataService.GetDetail(id);
            if (details == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<DetailDto>(details);
            dto.Url = Url.Link(nameof(GetDetail), new { id });

            return Ok(dto);
        }

        private DetailDto CreateDetailElementDto(Details details)
        {
            var dto = _mapper.Map<DetailDto>(details);
            dto.Url = Url.Link(nameof(GetDetail), new { id = details.TitleId.Trim() }); //trim to fix id whitespace in urls

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
                prev = Url.Link(nameof(GetDetails), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetDetails), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetDetails), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Details> details)
        {
            var items = details.Select(CreateDetailElementDto);

            var count = _dataService.NumberOfDetails();

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
