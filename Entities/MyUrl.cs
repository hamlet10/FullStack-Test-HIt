using System.Collections.Generic;

namespace UrlShortener.Entities
{
    public class MyUrl

    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public string Description { get; set; }
        public int? AplicationUserId { get; set; }
        public ICollection<Visitors> Visitors { get; set; }

    }
}
