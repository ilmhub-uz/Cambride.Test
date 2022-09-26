namespace Cambridge.Test.Question.Abstractions;

public interface IGenericAnswer<T>
{
    public T Answer { get; set; }
}
