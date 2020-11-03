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
        public IList<Users> GetUsers()
        {
            return _users;
        }


    }
}
