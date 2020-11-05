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
        private List<Users> _users = new List<Users>();

            public IList<Users> GetUsers()
            {
                var ctx = new Raw12Context();
                return ctx.Users.ToList();
            }

        private List<Details> _details = new List<Details>();

        public IList<Details> GetDetails()
        {
            var ctx = new Raw12Context();
            return ctx.Details.ToList();
        }
    }
}
// Test test
