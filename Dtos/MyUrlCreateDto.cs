using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Dtos
{
    public class MyUrlCreateDto
    {
        public string LongUrl { get; set; }
        public string Description { get; set; }
        public int? AplicationUserId { get; set; }
    }
}
