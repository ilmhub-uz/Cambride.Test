namespace Cambridge.Test.Data.Abstractions.Entity;

public class File
{
    public Guid? Id { get; set; }
    public string? Filename { get; set; }
    public string? Extension { get; set; }
    public string? Path { get; }
    public DateTime? CreatedAt { get; set; }
}