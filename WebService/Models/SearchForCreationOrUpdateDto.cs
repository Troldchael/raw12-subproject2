using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class SearchForCreationOrUpdateDto
    {
        public DateTime Timestamp { get; set; }
        public string Keyword { get; set; }
    }
}
