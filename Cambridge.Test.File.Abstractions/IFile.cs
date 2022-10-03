namespace Cambridge.Test.File.Abstractions;

public interface IFile
{
    public EAllowedExtension Extension { get; set; }
    public string? Filename { get; set; }
    public byte[]? Data { get; set; }
}