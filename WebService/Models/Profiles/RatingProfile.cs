using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;

namespace WebService.Models.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingHistory, RatingElementDto>();

               /* .ForMember(src => src.UserId,
                opt => opt.MapFrom(x => x.UserId)); //try to map id so url will work*/

            //use to add from other tables to dto
            /*CreateMap<Exampleclass, ExampleDto>()
                .ForMember(src => src.Category,
                    opt => opt.MapFrom(x => x.Category.Name));*/
        }
    }
}