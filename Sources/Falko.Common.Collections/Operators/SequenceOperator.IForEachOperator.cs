namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IForEachOperator
    {
        void ForEach(Action<T> action);

        void ForEach(Action<T, int> action);

        void ForEach<TArgument>(TArgument argument, Action<T, TArgument> action);

        void ForEach<TArgument>(TArgument argument, Action<T, int, TArgument> action);
    }
}
