using Cambridge.Test.File.Abstractions;

namespace Cambridge.Test.Question.Abstractions;

public interface IHasImage
{
    public IImageFile Image { get; set; }
}
