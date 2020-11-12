using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class RatingElementDto
    {
        public int UserId { get; set; }
        public string Rating { get; set; }
        public string TitleId { get; set; }
        public string Url { get; set; }
    }
}
