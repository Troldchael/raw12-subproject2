using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public class SearchHistory
    {
        //properties
        public int UserId { get; set; }
        public string Timestamp { get; set; }
        public string Keyword { get; set; }

        //navigation poperties
        public string Type { get; set; } //dummy
    }
}