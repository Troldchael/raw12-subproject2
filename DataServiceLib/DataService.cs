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
            var _users = ctx.Users.ToList();
            return _users;
        }

        public IList<Users> GetUsers()
        {
            return UserToList();
        }

        public Users GetUser(string id)
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

        public bool DeleteUser(string id)
        {
            var dbCat = GetUser(id);
            if (dbCat == null)
            {
                return false;
            }
            UserToList().Remove(dbCat);
            return true;
        }
    }
}
