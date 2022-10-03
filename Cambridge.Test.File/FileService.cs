using Cambridge.Test.File.Abstractions;

namespace Cambridge.Test.File;

public class FileService : IFileService
{
    private const string PUBLIC_DIRECTORY = "public";
    private const string PRIVATE_DIRECTORY = "private";

    public ValueTask<bool> ExistsAsync(string filename, CancellationToken cancellationToken = default)
        => ValueTask.FromResult(System.IO.File.Exists(Path.Combine(PUBLIC_DIRECTORY, filename)));

    public async ValueTask<byte[]?> GetFileOrDefaultAsync(string filename, CancellationToken cancellationToken = default)
    {
        if((await ExistsAsync(filename, cancellationToken)) is false)
            return null;

        var path = Path.Combine(PUBLIC_DIRECTORY, filename);

        return await System.IO.File.ReadAllBytesAsync(path, cancellationToken);
    }

    public async ValueTask<Guid?> SaveAsync(IFile file, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(file.Data);

        if (Directory.Exists(PUBLIC_DIRECTORY) is false)
            Directory.CreateDirectory(PUBLIC_DIRECTORY);

        var id = Guid.NewGuid();

        var path = Path.Combine(PUBLIC_DIRECTORY, $"{id}.{file.Extension}");

        await System.IO.File.WriteAllBytesAsync(path, file.Data, cancellationToken);

        return id;
    }
}