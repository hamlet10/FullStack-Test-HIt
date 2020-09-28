using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Entities
{
    public class VisitiorModel
    {
        public int MyUrlId { get; set; }
        public string BrowserName { get; set; }
        public string IP { get; set; }
    }
}
