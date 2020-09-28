using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public class ShortenerService
    {
       public static string GenerateShortUrl()
        {
            string shortUrl = "http//";
            string TrollUrl = Guid.NewGuid().ToString();
            shortUrl = shortUrl + TrollUrl;
            shortUrl = shortUrl.Replace("-", string.Empty);
            return shortUrl;
        }

        
    }
}
