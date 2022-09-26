using Cambridge.Test.File.Abstractions;
using Cambridge.Test.Question.Abstractions;

namespace Cambridge.Test.Question;

public class CheckboxWithImageQuestion : ICheckboxWithImageQuestion
{
    public EQuestionType Type { get; set; }
    public bool CheckedState { get; set; }
    public IImageFile? Image { get; set; }
    public string? Text { get; set; }
    public bool Answer { get; set; }
}