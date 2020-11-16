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
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        //navigation properties
        //dont think its needed in users
    }
}