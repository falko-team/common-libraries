using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Utils;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.ICopyToOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped in T[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        AsSpan().CopyTo(SpanMarshal.AsSpan(array, _itemsCount));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped in T[] array, int startIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        AsSpan().CopyTo(new Span<T>(array, startIndex, _itemsCount));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped in T[] array, int startIndex, int length)
    {
        ArgumentNullException.ThrowIfNull(array);

        AsSpan().CopyTo(new Span<T>(array, startIndex, length));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped in T[] array, Index startIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        var length = array.Length;
        var offset = startIndex.GetOffset(length);

        AsSpan().CopyTo(new Span<T>(array, startIndex.GetOffset(length), length - offset));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped in T[] array, Range range)
    {
        ArgumentNullException.ThrowIfNull(array);

        var length = array.Length;

        var startIndex = range.Start.GetOffset(length);
        var endIndex = range.End.GetOffset(length);

        if ((uint)endIndex > length || (uint)startIndex > endIndex)
        {
            throw new ArgumentOutOfRangeException(nameof(range), "Range is out of bounds.");
        }

        AsSpan().CopyTo(new Span<T>(array, startIndex, endIndex - startIndex));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped in ArraySegment<T> segment)
    {
        AsSpan().CopyTo(new Span<T>(segment.Array, segment.Offset, _itemsCount));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped in Memory<T> memory)
    {
        AsSpan().CopyTo(memory.Span);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(scoped Span<T> span)
    {
        AsSpan().CopyTo(span);
    }
}
