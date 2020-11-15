﻿using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;

namespace DataServiceLib
{
    public interface IDataService
    {
        // Framework Interfaces ////////
        // only users, searches and ratings implement CRUD

        // users interface
        IList<Users> GetUsers();
        bool CreateUser(Users users);
        bool UpdateUser(Users users);
        bool DeleteUser(int id);
        Users GetUser(int id);
        IList<Users> GetUserInfo(int page, int pageSize);
        int NumberOfUsers();

        // search interface
        IList<SearchHistory> GetSearches();
        bool CreateSearch(SearchHistory searches);
        bool UpdateSearch(SearchHistory searches);
        bool DeleteSearch(int id);
        SearchHistory GetSearch(int id);
        IList<SearchHistory> GetSearchInfo(int page, int pageSize);
        int NumberOfSearches();

        //ratings interface
        IList<RatingHistory> GetRatings();
        bool CreateRating(RatingHistory ratings);
        bool UpdateRating(RatingHistory ratings);
        bool DeleteRating(int id);
        RatingHistory GetRating(int id);
        IList<RatingHistory> GetRatingInfo(int page, int pageSize);
        int NumberOfRatings();

        //titlebooking interface
        IList<TitleBookmarking> GetTBookings();

/*      bool CreateTBooking(TitleBookmarking tbookings);
        bool UpdateTBooking(TitleBookmarking tbookings);
        bool DeleteTBooking(int id);*/
        TitleBookmarking GetTBooking(int id);
        IList<TitleBookmarking> GetTBookInfo(int page, int pageSize);
        int NumberOfTBookings();

        //actorbooking interface
        IList<ActorBookmarking> GetABookings();

/*      bool CreateABooking(ActorBookmarking abookings);
        bool UpdateABooking(ActorBookmarking abookings);
        bool DeleteABooking(int id);*/
        ActorBookmarking GetABooking(int id);
        IList<ActorBookmarking> GetABookInfo(int page, int pageSize);
        int NumberOfABookings();


        //Movie Data interfaces///////////

        //actors interface
        IList<Actors> GetActors();
        Actors GetActor(string id);
        IList<Actors> GetActorInfo(int page, int pageSize);
        int NumberOfActors();

        //movies interface
        IList<Movies> GetMovies();
        Movies GetMovie(string id);
        IList<Movies> GetMovieInfo(int page, int pageSize);
        int NumberOfMovies();

        //genres interface
        IList<Genres> GetGenres();
        Genres GetGenre(string id);
        IList<Genres> GetGenreInfo(int page, int pageSize);
        int NumberOfGenres();

        //details interface
        IList<Details> GetDetails();
        Details GetDetail(string id);
        IList<Details> GetDetailInfo(int page, int pageSize);
        int NumberOfDetails();

    }
}