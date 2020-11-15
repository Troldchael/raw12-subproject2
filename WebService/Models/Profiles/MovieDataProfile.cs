using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Moviedata;

namespace WebService.Models.Profiles
{
    public class MovieDataProfile : Profile
    {
        public MovieDataProfile()
        {

            //actor map
            CreateMap<Actors, ActorDto>();

            //movies map
            CreateMap<Movies, MovieDto>();

            //genre map
            CreateMap<Genres, GenreDto>();

            //details map
            CreateMap<Details, DetailDto>();


            //used to add from other tables to dto
            /*CreateMap<Exampleclass, ExampleDto>()
                .ForMember(src => src.Category,
                    opt => opt.MapFrom(x => x.Category.Name));*/
        }


    }
}