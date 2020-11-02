using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Framework
{
    public class RatingHistory
    {
        //properties
        public int UserId { get; set; }
        public string Rating { get; set; }
        public string TitleId { get; set; }

        //navigation poperties
        public string Type { get; set; } //dummy
    }
}