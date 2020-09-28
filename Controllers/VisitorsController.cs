using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Entities;
using UrlShortener.Persistence;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly UrlShortenerDbContext _urlShortenerDbContext;

        public VisitorsController(UrlShortenerDbContext urlShortenerDbContext)
        {
            _urlShortenerDbContext = urlShortenerDbContext;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<Visitors>> create ([FromBody] VisitiorModel model)
        {
            var visitor = new Visitors
            {
                MyUrlId = model.MyUrlId,
                BrowserName = model.BrowserName,
                IP = model.IP
            };
            _urlShortenerDbContext.Visitors.Add(visitor);
            await _urlShortenerDbContext.SaveChangesAsync();
            return Ok(visitor);


        }
    }
}
