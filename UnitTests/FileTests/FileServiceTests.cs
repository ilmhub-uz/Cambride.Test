using System.Text;
using Cambridge.Test.File;
using Cambridge.Test.File.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FileTests;

public class FileServiceTests : IDisposable
{
    private const string PUBLIC_FOLDER = "public";

    private readonly ServiceProvider serviceProvider;

    public FileServiceTests()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IFileService, FileService>();
        serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [Theory]
    [InlineData("non-existingfile.txt")]
    [InlineData(" ")]
    [InlineData("")]
    public async Task FileServiceShouldReturnFalseWhenFileDoesntExist(string filename)
    {
        var fileService = serviceProvider.GetRequiredService<IFileService>();
        var result = await fileService.ExistsAsync(filename, CancellationToken.None);
        Assert.False(result, "Non existing file should return false.");
    }

    [Fact]
    public async Task FileServiceExistsShouldReturnTrueForExistingFiles()
    {
        var fileService = serviceProvider.GetRequiredService<IFileService>();

        // given
        var stringData = "Hello world";
        var byteData = Encoding.ASCII.GetBytes(stringData);

        var file = new Cambridge.Test.File.File(
            type: EFileType.Document,
            filename: "hello-world",
            extension: EAllowedExtension.txt,
            data: byteData);

        var fileId = await fileService.SaveAsync(file, CancellationToken.None);
        var existingFilename = $"{fileId}.{file.Extension}";

        // when
        var result = await fileService.ExistsAsync(existingFilename);

        // should
        Assert.True(result, "Newly created file should exist.");
    }

    [Fact]
    public async Task SaveAsyncShouldThrowWhenDataIsNull()
    {
        var fileService = serviceProvider.GetRequiredService<IFileService>();

        // given
        var file = new Cambridge.Test.File.File(
            type: EFileType.Document,
            filename: "hello-world",
            extension: EAllowedExtension.txt,
            data: null);

        // when
        var task = async () => await fileService.SaveAsync(file, CancellationToken.None);

        // should
        await Assert.ThrowsAsync<ArgumentNullException>(task);
    }

    [Fact]
    public async Task GetFileOrDefaultAsyncShouldReturnByteArrayDataWhenFileExists()
    {
        var fileService = serviceProvider.GetRequiredService<IFileService>();

        // given
        var stringData = "this is to create a new file for unit test";
        var byteData = Encoding.ASCII.GetBytes(stringData);

        var file = new Cambridge.Test.File.File(
            type: EFileType.Document,
            filename: "exampleFile",
            extension: EAllowedExtension.txt,
            data: byteData);

        // when 
        var fileId = await fileService.SaveAsync(file, CancellationToken.None);
        var existingFilename = $"{fileId}.{file.Extension}";
        var result = async () => await fileService.GetFileOrDefaultAsync(existingFilename, CancellationToken.None);

        // should
        Assert.NotNull(result);
    }

    public void Dispose()
    {
        if (Directory.Exists(PUBLIC_FOLDER))
            Directory.Delete(PUBLIC_FOLDER, true);
    }
}

