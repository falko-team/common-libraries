namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IFirstOperator
    {
        T? FirstOrDefault();

        T? FirstOrDefault(Func<T, bool> predicate);

        T First();

        T First(Func<T, bool> predicate);
    }
}
