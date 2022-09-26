using Cambridge.Test.File.Abstractions;

namespace Cambridge.Test.File;

public class File : IFile
{
    public EFileType Type { get; set; }
    public string? Filename { get; set; }
}