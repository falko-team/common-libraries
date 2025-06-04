namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IAsSpanOperator
    {
        ReadOnlySpan<T> AsSpan();

        ReadOnlySpan<T> AsSpan(int startIndex);

        ReadOnlySpan<T> AsSpan(int startIndex, int length);

        ReadOnlySpan<T> AsSpan(Index startIndex);

        ReadOnlySpan<T> AsSpan(Range range);
    }
}
