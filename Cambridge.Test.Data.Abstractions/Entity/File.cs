using System.ComponentModel.DataAnnotations;

namespace Cambridge.Test.Data.Abstractions.Entity;

public class File
{
    [Key]
    public Guid? Id { get; set; }

    [MaxLength(50)]
    public string? Filename { get; set; }
    
    [MaxLength(20)]
    public string? Extension { get; set; }
    
    public string? Path
    {
        get
        {
            return $"{Filename}.{Extension}";
        }
        set {}
    }
    public DateTime? CreatedAt { get; set; }
}