using Microsoft.EntityFrameworkCore;

namespace Cambridge.Test.Data.Abstractions;

public interface IDbContext
{
    public DbSet<Entity.File> Files { get; set; }
}