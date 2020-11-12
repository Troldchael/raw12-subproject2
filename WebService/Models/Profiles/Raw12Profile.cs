using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;

namespace WebService.Models.Profiles
{
    public class Raw12Profile : Profile
    {
        public Raw12Profile()
        {
            //usermap
            CreateMap<Users, UsersDto>();
            CreateMap<UserForCreationOrUpdateDto, Users>();
            CreateMap<Users, UserElementDto>();

            //searchmap
            CreateMap<SearchHistory, SearchElementDto>();

            //ratingmap
            CreateMap<RatingHistory, RatingElementDto>();
        }

        
    }
}