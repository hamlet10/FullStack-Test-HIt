using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace UrlShortener.Entities
{
    public class Visitors
    {
        public int Id { get; set; }
        public int MyUrlId { get; set; }
        public string BrowserName { get; set; }
        public string IP { get; set; }
        public MyUrl MyUrl { get; set; }

    }
}
