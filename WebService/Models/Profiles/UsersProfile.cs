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
            CreateMap<UserUpdateDto, Users>();
            CreateMap<Users, UserElementDto>();

            //use to add from other tables to dto
            /*CreateMap<Exampleclass, ExampleDto>()
                .ForMember(src => src.Category,
                    opt => opt.MapFrom(x => x.Category.Name));*/
        }
    }
}