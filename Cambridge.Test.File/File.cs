using Cambridge.Test.File.Abstractions;

namespace Cambridge.Test.File;

public class File : IFile
{
    public File(EFileType type, string? filename, EAllowedExtension extension, byte[]? data)
    {
        Type = type;
        Filename = filename;
        Extension = extension;
        Data = data;
    }

    public EFileType Type { get; set; }
    public string? Filename { get; set; }
    public EAllowedExtension Extension { get; set; }
    public byte[]? Data { get; set; }
}