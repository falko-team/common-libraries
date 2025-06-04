namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface ISingleOperator
    {
        T? SingleOrDefault();

        T? SingleOrDefault(Func<T, bool> predicate);

        T Single();

        T Single(Func<T, bool> predicate);
    }
}
