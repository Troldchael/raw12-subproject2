using System.Collections.Generic;

using DataServiceLib.Framework;

using DataServiceLib.Moviedata;

namespace DataServiceLib
{
    public interface IDataService
    {

        IList<Users> GetUsers();

        void CreateUser(Users users);
        bool UpdateUser(Users users);
        bool DeleteUser(int id);
        IList<Details> GetDetails();

        IList<Actors> GetActors();
        Actors GetActor(string id);

        IList<Genres> GetGenres();

        IList<Ratings> GetRatings();



        /*Category GetCategory(int id);
        void CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);*/

        Users GetUser(int id);
        

        IList<Users> GetUserInfo(int page, int pageSize);
       
        int NumberOfUsers();
    }
}