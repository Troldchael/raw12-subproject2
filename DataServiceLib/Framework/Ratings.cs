using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Framework
{
    public class Ratings
    {
        //properties
        public String Tconst { get; set; }
        public double Averagerating { get; set; }
        public int Numvotes { get; set; }



        //navigation properties
        //public string Type { get; set; } //dummy
    }
}