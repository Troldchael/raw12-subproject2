using System.Collections.Generic;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;

namespace DataServiceLib
{
    public interface IDataService
    {
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
        SearchHistory GetSearch(int id);
        IList<SearchHistory> GetSearchInfo(int page, int pageSize);
        int NumberOfSearches();

        //ratings interface
        IList<RatingHistory> GetRatings();
        RatingHistory GetRating(int id);
        IList<RatingHistory> GetRatingInfo(int page, int pageSize);
        int NumberOfRatings();

        //actors interface
        IList<Actors> GetActors();
        Actors GetActor(string id);
        IList<Actors> GetActorInfo(int page, int pageSize);
        int NumberOfActors();

    }
}