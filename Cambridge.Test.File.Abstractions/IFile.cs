namespace Cambridge.Test.File.Abstractions;

public interface IFile
{
    public EAllowedExtension Extension { get; set; }
    public string? Filename { get; set; }
    public byte[] Data { get; set; }
}

public enum EAllowedExtension
{
    png,
    jpeg,
    jpg,
    mp3,
    mp4,
    pdf
}
