namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IToArrayOperator
    {
        T[] ToArray();

        T[] ToArray(int startIndex);

        T[] ToArray(int startIndex, int length);

        T[] ToArray(Index startIndex);

        T[] ToArray(Range range);
    }
}
