namespace Cambridge.Test.File.Abstractions;

public interface IFileService
{
    ValueTask<Guid?> SaveAsync(IFile file, CancellationToken cancellationToken = default);
    ValueTask<bool> ExistsAsync(Guid? id, CancellationToken cancellationToken = default);
    ValueTask<IFile?> GetFileOrDefaultAsync(Guid? id, CancellationToken cancellationToken = default);
}