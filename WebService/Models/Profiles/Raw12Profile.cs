using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;

namespace WebService.Models.Profiles
{
    public class Raw12Profile : Profile
    {
        public Raw12Profile()
        {
            //FRAMEWORK

            //usermap
            CreateMap<Users, UsersDto>();
            CreateMap<UserForCreationOrUpdateDto, Users>();
            CreateMap<Users, UserElementDto>();

            //searchmap
            CreateMap<SearchHistory, SearchElementDto>();
            CreateMap<SearchForCreationOrUpdateDto, SearchHistory>();

            //ratingmap
            CreateMap<RatingHistory, RatingElementDto>();
            CreateMap<RatingForCreationOrUpdateDto, RatingHistory>();

            //tbooking map
            CreateMap<TitleBookmarking, TBookElementDto>();

            //abookingmap
            CreateMap<ActorBookmarking, ABookElementDto>();


            //MOVIEDATA

            //actormap
            CreateMap<Actors, ActorDto>();

            //movies map
            CreateMap<Movies, MovieDto>();

            //genre map
            CreateMap<Genres, GenreElementDto>();
        }

        
    }
}