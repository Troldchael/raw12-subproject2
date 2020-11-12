using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
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

        public bool UpdateUser(Users users)
        {
            throw new NotImplementedException();
        }


        public Users GetUserId(int id)
        {
            return UserToList().FirstOrDefault(x => x.UserId == id);
        }

        public Users GetUserName(string username)
        {
            return UserToList().FirstOrDefault(x => x.Username == username);
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

        public void CreateUser(string username, string password, string salt)
        {
            var users = new Users();

            {
                
            }

            dbCat.Username = Id.Username;
            dbCat.Email = Id.Email;
            dbCat.Password = Id.Password;
            dbCat.Salt = Id.Salt;

            return;
        }

      
        public bool UpdateUser(Users users, int id)
        {
            var dbCat = GetUserId(id);
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
            var dbCat = GetUserId(id);
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
