using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class DetailDto
    {
        public string TitleId { get; set; }
        public string Startyear { get; set; }
        public string EndYear { get; set; }
        public int RunTimeMinutes { get; set; }
        public string Url { get; set; }
    }
}
