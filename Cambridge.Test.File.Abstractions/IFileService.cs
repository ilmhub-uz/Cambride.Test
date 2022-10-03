namespace Cambridge.Test.File.Abstractions;

public interface IFileService
{
    ValueTask<Guid?> SaveAsync(IFile file, CancellationToken cancellationToken = default);
    ValueTask<bool> ExistsAsync(string filename, CancellationToken cancellationToken = default);
    ValueTask<byte[]?> GetFileOrDefaultAsync(string filename, CancellationToken cancellationToken = default);
}