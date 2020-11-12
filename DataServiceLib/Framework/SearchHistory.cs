﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Framework
{
    public class SearchHistory
    {
        //properties
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Keyword { get; set; }

        //navigation poperties
        //public string Type { get; set; } //dummy
    }
}