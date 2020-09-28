using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Dtos;
using UrlShortener.Entities;
using UrlShortener.Persistence;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlShortenerDbContext _urlShortenerDbContext;

        public UrlController(UrlShortenerDbContext urlShortenerDbContext)
        {
            _urlShortenerDbContext = urlShortenerDbContext;
        }
        //get all
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MyUrlDto>>> Get(int id)
        {

            var myUrl = await _urlShortenerDbContext.MyUrls.Where(a => a.AplicationUserId == id).Select(a => new MyUrlDto
            {
                Id = a.Id,
                AplicationUserId = a.AplicationUserId,
                Description = a.Description,
                LongUrl = a.LongUrl,
                ShortUrl = a.ShortUrl,
                VisitorCount = a.Visitors.Count()
            })
                .OrderByDescending(a => a.VisitorCount).ToListAsync();
            return Ok(myUrl);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> CreateUrl([FromBody] MyUrlCreateDto model)
        {

            string shortUrl = Guid.NewGuid().ToString().GetHashCode().ToString("x");
            var myUrl = new MyUrl
            {
                LongUrl = model.LongUrl,
                ShortUrl = $"http://shortenerurl/{shortUrl}",
                Description = model.Description,
                AplicationUserId = model.AplicationUserId

            };
            _urlShortenerDbContext.MyUrls.Add(myUrl);
            await _urlShortenerDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
