using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib.Moviedata;

namespace DataServiceLib.Framework
{
    public class DataService : IDataService
    {

        public IList<Users> UserToList()
        {
            var ctx = new Raw12Context();
            var users = ctx.Users.ToList();
            return users;
        }

        public IList<Users> GetUsers()
        {
            return UserToList();
        }

        public Users GetUser(int id)
        {
            return UserToList().FirstOrDefault(x => x.UserId == id);
        }

        public IList<Users> GetUserInfo(int page, int pageSize)
        {
            return UserToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfUsers()
        {
            return UserToList().Count;
        }

        public void CreateUser(Users users)
        {
            var maxId = UserToList().Max(x => x.UserId);
            users.UserId = maxId + 1;
            UserToList().Add(users);
        }

        public bool UpdateUser(Users users)
        {
            var dbCat = GetUser(users.UserId);
            if (dbCat == null)
            {
                return false;
            }
            dbCat.Username = users.Username;
            dbCat.Email = users.Email;
            dbCat.Password = users.Password;
            return true;
        }

        public bool DeleteUser(int id)
        {
            var dbCat = GetUser(id);
            if (dbCat == null)
            {
                return false;
            }
            UserToList().Remove(dbCat);
            return true;
        }

        private List<Details> _details = new List<Details>();

        public IList<Details> GetDetails()
        {
            var ctx = new Raw12Context();
            return ctx.Details.ToList();
        }

        private List<Actors> _actors = new List<Actors>();

        public IList<Actors> GetActors()
        {
            var ctx = new Raw12Context();
            return ctx.Actors.ToList();
        }

        private List<Genres> _genres = new List<Genres>();

        public IList<Genres> GetGenres()
        {
            var ctx = new Raw12Context();
            return ctx.Genres.ToList();
        }

        private List<Ratings> _ratings = new List<Ratings>();

        public IList<Ratings> GetRatings()
        {
            var ctx = new Raw12Context();

            return ctx.Ratings.ToList();
        }
    }
}
// Test test
