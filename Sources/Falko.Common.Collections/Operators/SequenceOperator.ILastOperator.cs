namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface ILastOperator
    {
        T? LastOrDefault();

        T? LastOrDefault(Func<T, bool> predicate);

        T? LastOrDefault(Func<T, int, bool> predicate);

        T? LastOrDefault<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate);

        T? LastOrDefault<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate);

        T Last();

        T Last(Func<T, bool> predicate);

        T Last(Func<T, int, bool> predicate);

        T Last<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate);

        T Last<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate);
    }
}
