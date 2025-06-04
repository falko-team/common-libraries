namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IAsMemoryOperator
    {
        ReadOnlyMemory<T> AsMemory();

        ReadOnlyMemory<T> AsMemory(int startIndex);

        ReadOnlyMemory<T> AsMemory(int startIndex, int length);

        ReadOnlyMemory<T> AsMemory(Index startIndex);

        ReadOnlyMemory<T> AsMemory(Range range);
    }
}
