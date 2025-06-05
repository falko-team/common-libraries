namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IAnyOperator
    {
        bool Any();

        bool Any(Func<T, bool> predicate);

        bool Any(Func<T, int, bool> predicate);

        bool Any<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate);

        bool Any<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate);
    }
}
