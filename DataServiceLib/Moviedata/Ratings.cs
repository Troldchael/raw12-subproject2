using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Moviedata
{
    public class Ratings
    {
        //properties
        public int TitleId { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }

        //navigation poperties
        public string Type { get; set; } //dummy
    }
}