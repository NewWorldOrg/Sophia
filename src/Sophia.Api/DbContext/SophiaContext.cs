namespace Sophia.Api.DbContext;

using Microsoft.EntityFrameworkCore;
using Models;

public class SophiaContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<User>();
    }
}