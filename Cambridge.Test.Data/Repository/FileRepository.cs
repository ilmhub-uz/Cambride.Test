using Cambridge.Test.Data.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cambridge.Test.Data.Repository;

public class FileRepository : IFileRepository
{
    private readonly AppDbContext _context;

    public FileRepository(AppDbContext context)
    {
        _context = context;
    }
    public async ValueTask<Abstractions.Entity.File?> GetFileOrDefaultAsync(Guid? id, CancellationToken cancellationToken = default)
        => await _context.Set<Abstractions.Entity.File>().FirstOrDefaultAsync(f => f.Id == id);

    public async ValueTask<Abstractions.Entity.File> InsertAsync(Abstractions.Entity.File file, CancellationToken cancellationToken = default)
    {
        var entry = await _context.Set<Abstractions.Entity.File>().AddAsync(file);

        await _context.SaveChangesAsync();

        return entry.Entity;
    }
}