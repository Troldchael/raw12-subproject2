using System.Collections.Generic;
<<<<<<< HEAD
using DataServiceLib.Framework;
=======
using DataServiceLib.Moviedata;
>>>>>>> origin/Mads

namespace DataServiceLib
{
    public interface IDataService
    {

        IList<Users> GetUsers();

<<<<<<< HEAD
        void CreateUser(Users users);
        bool UpdateUser(Users users);
        bool DeleteUser(int id);
=======
        IList<Details> GetDetails();

        IList<Actors> GetActors();

        IList<Genres> GetGenres();

        IList<Ratings> GetRatings();



        /*Category GetCategory(int id);
        void CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);*/
>>>>>>> origin/Mads

        Users GetUser(int id);

        IList<Users> GetUserInfo(int page, int pageSize);
       
        int NumberOfUsers();
    }
}