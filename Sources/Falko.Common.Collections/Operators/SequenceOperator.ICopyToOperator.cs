namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface ICopyToOperator
    {
        void CopyTo(scoped in T[] array);

        void CopyTo(scoped in T[] array, int startIndex);

        void CopyTo(scoped in T[] array, int startIndex, int length);

        void CopyTo(scoped in T[] array, Index startIndex);

        void CopyTo(scoped in T[] array, Range range);

        void CopyTo(scoped in ArraySegment<T> segment);

        void CopyTo(scoped in Memory<T> memory);

        void CopyTo(scoped Span<T> span);
    }
}
