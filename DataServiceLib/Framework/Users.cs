using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Framework
{
    public class Users
    {
        public static List<Users> users { get; set; }
        //properties
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }

        //navigation properties
        //dont think its needed in users
    }
}