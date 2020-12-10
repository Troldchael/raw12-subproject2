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
            return UserToList().FirstOrDefault(x => x.user_id == id);
        }

        public Users GetUser(string username)
        {
            return UserToList().FirstOrDefault(x => x.username == username);
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
       
        public Users CreateUser(string email, string username, string password, string salt)
        {
            var cont = new Raw12Context();
          
            var newUser = new Users {
                user_id = cont.Users.Max(x => x.user_id) + 1,
                username = username,
                password = password, 
                email = email,
                salt = salt

        };
            
            cont.Users.Add(newUser);
            return newUser;
        }

      
        public bool UpdateUser(Users users, int id)
        {
            var dbCat = GetUserId(id);
            if (dbCat == null)
            {
                return false;
            }
            dbCat.username = users.username;
            dbCat.email = users.email;
            dbCat.password = users.password;
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

        public IList<Details> GetDetails()
        {
            var ctx = new Raw12Context();
            return ctx.Details.ToList();
        }

        private  readonly List<Actors> _actors = new List<Actors>();

        public IList<Actors> GetActors()
        {
            var ctx = new Raw12Context();
            return ctx.Actors.ToList();
        }

        public IList<Genres> GetGenres()
        {
            var ctx = new Raw12Context();
            return ctx.Genres.ToList();
        }

       
        public IList<Ratings> GetRatings()
        {
            var ctx = new Raw12Context();

            return ctx.Ratings.ToList();
        }
    }
}
// Test test
