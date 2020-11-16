using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib.Framework
{
    class Data
    {
        public static List<Users> users {get; set;}

        static Data()
        {
            users = new List<Users>
            {
                new Users {UserId = 100, Username = "Test user"}
            };
        }
    }
}
