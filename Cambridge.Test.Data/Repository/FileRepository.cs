using Cambridge.Test.Data.Abstractions.Repository;

namespace Cambridge.Test.Data.Repository;

public class FileRepository : IFileRepository
{
    public ValueTask<Abstractions.Entity.File> GetFileOrDefaultAsync(Guid? id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Abstractions.Entity.File> InsertAsync(Abstractions.Entity.File file, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}