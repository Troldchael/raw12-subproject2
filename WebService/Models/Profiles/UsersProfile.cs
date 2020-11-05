using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;

namespace WebService.Models.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UsersDto>();
            CreateMap<UserForCreationOrUpdateDto, Users>(); //use for create user dto
        }
    }
}