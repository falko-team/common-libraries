namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IFirstOperator
    {
        T? FirstOrDefault();

        T? FirstOrDefault(Func<T, bool> predicate);

        T? FirstOrDefault(Func<T, int, bool> predicate);

        T? FirstOrDefault<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate);

        T? FirstOrDefault<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate);

        T First();

        T First(Func<T, bool> predicate);

        T First(Func<T, int, bool> predicate);

        T First<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate);

        T First<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate);
    }
}
