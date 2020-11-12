using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class SearchElementDto
    {
        public int UserId { get; set; }
        public string Timestamp { get; set; }
        public string Keyword { get; set; }
        public string Url { get; set; }
    }
}
