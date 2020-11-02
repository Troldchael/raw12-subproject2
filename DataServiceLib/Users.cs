using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public class Users
    {
        //properties
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //navigation poperties
        public string Type { get; set; } //dummy
    }
}