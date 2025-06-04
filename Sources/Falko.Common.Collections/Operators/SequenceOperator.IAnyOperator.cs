namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IAnyOperator
    {
        bool Any();

        bool Any(Func<T, bool> predicate);
    }
}
