namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IContainsOperator
    {
        bool Contains(T value);

        bool Contains(T value, IEqualityComparer<T> comparer);
    }
}
