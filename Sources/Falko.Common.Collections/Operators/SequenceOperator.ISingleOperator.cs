namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface ISingleOperator
    {
        T? SingleOrDefault();

        T? SingleOrDefault(Func<T, bool> predicate);

        T? SingleOrDefault(Func<T, int, bool> predicate);

        T? SingleOrDefault<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate);

        T? SingleOrDefault<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate);

        T Single();

        T Single(Func<T, bool> predicate);

        T Single(Func<T, int, bool> predicate);

        T Single<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate);
    }
}
