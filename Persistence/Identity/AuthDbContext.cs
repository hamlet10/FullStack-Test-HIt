using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Entities;

namespace UrlShortener.Persistence.Identity
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base (options)
        {

        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(a => { a.HasKey(u => u.Id);
                a.HasIndex(u => u.NormalizedEmail).IsUnique();
            });
        }
    }
}
