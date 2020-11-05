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
        private List<Users> _users = new List<Users>();

        public IList<Users> GetUsers()
        {
            var ctx = new Raw12Context();
            return ctx.Users.ToList();
        }


    }
}
