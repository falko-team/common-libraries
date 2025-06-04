namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface ILastOperator
    {
        T? LastOrDefault();

        T? LastOrDefault(Func<T, bool> predicate);

        T Last();

        T Last(Func<T, bool> predicate);
    }
}
