using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            var ctx = new Raw12Context();
            var users = ctx.Users;

            return ctx.Users.FirstOrDefault(x => x.UserId == id);
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

        public bool CreateUser(Users users)
        {
            var maxId = UserToList().Max(x => x.UserId);
            users.UserId = maxId + 1;

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

        public bool UpdateUser(Users users)
        {
            var cont = new Raw12Context();

            var dbCat = GetUser(users.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.Username = users.Username;
            dbCat.Email = users.Email;
            dbCat.Password = users.Password;

            cont.Users.Update(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            var cont = new Raw12Context();
            var dbCat = GetUser(id);
            if (dbCat == null)
            {
                return false;
            }

            cont.Users.Remove(dbCat);
            cont.SaveChanges();
            return true;
        }
    }
}
