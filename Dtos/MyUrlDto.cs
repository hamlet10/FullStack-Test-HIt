using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Dtos
{
    public class MyUrlDto
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public string Description { get; set; }
        public int? AplicationUserId { get; set; }
        public int VisitorCount { get; set; }
    }
}
