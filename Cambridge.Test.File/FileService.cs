using Cambridge.Test.File.Abstractions;

namespace Cambridge.Test.File;

public class FileService : IFileService
{
    private const string PUBLIC_DIRECTORY = "/public";
    private const string PRIVATE_DIRECTORY = "/private";

    public ValueTask<bool> ExistsAsync(Guid? id, CancellationToken cancellationToken = default)
        => ValueTask.FromResult(Directory.EnumerateFiles(PUBLIC_DIRECTORY)
            .Any(filename => Path.GetFileNameWithoutExtension(filename) == id.ToString()));

    public async ValueTask<IFile?> GetFileOrDefaultAsync(Guid? id, CancellationToken cancellationToken = default)
    {
        if((await ExistsAsync(id)) is false)
            return null;

        var path = Path.Combine(PUBLIC_DIRECTORY, $"{id}.{file.Extension}");

        var bytes = System.IO.File.ReadAllBytesAsync(path, cancellationToken);
    }

    public async ValueTask<Guid?> SaveAsync(IFile file, CancellationToken cancellationToken = default)
    {
        if (Directory.Exists(PUBLIC_DIRECTORY) is false)
            Directory.CreateDirectory(PUBLIC_DIRECTORY);

        var id = Guid.NewGuid();

        var path = Path.Combine(PUBLIC_DIRECTORY, $"{id}.{file.Extension}");

        await System.IO.File.WriteAllBytesAsync(path, file.Data, cancellationToken);

        return id;
    }

}