using Microsoft.EntityFrameworkCore;
using UrlShortener.Persistence.Identity;

public class AuthDbContextFactory : DesignTimeDbContextFactoryBase<AuthDbContext>
{
    protected override AuthDbContext CreateNewInstance(DbContextOptions<AuthDbContext> options)
    {
        return new AuthDbContext(options);
    }
}