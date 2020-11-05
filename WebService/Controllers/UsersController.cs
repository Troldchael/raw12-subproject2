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
        private const int MaxPageSize = 25;


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
        public IActionResult GetUser(string id)
        {
            var users = _dataService.GetUser(id);
            if (users == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<UserDetailsDto>(users);
            dto.Url = Url.Link(nameof(GetUser), new { id });

            return Ok(dto);
        }


        private UserElementDto CreateUserElementDto(Users user)
        {
            var dto = _mapper.Map<UserElementDto>(user);
            dto.Url = Url.Link(nameof(GetUser), new { user.UserId });
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


}
