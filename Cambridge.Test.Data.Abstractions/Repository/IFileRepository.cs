namespace Cambridge.Test.Data.Abstractions.Repository;

interface IFileRepository
{
    ValueTask<Entity.File> InsertAsync(Entity.File file, CancellationToken cancellationToken = default);
    ValueTask<Entity.File> GetFileOrDefaultAsync(Guid? id, CancellationToken cancellationToken = default);
}