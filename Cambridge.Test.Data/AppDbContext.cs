using Cambridge.Test.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cambridge.Test.Data;

public class AppDbContext : DbContext, IDbContext
{
    public DbSet<Abstractions.Entity.File>? Files { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public override int SaveChanges()
    {
        foreach(var entry in ChangeTracker.Entries<Abstractions.Entity.File>())
        {
            if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
        }
        return base.SaveChanges();
    }
}