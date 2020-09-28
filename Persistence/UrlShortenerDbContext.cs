using Microsoft.EntityFrameworkCore;
using UrlShortener.Entities;

namespace UrlShortener.Persistence
{
    public class UrlShortenerDbContext : DbContext
    {
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options)
        {

        }

        public DbSet<MyUrl> MyUrls { get; set; }
        public DbSet<Visitors> Visitors { get; set; }

    }
}
