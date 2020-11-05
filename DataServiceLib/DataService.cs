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
    }
}
