using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Asserts;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IAsMemoryOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<T> AsMemory()
    {
        return new ReadOnlyMemory<T>(_items);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<T> AsMemory(int startIndex)
    {
        return new ReadOnlyMemory<T>(_items, startIndex, _itemsCount - startIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<T> AsMemory(int startIndex, int length)
    {
        return new ReadOnlyMemory<T>(_items, startIndex, length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<T> AsMemory(Index startIndex)
    {
        var itemsCount = _itemsCount;

        var itemsOffset = startIndex.GetOffset(itemsCount);

        return new ReadOnlyMemory<T>(_items, itemsOffset, itemsCount - itemsOffset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlyMemory<T> AsMemory(Range range)
    {
        var itemsCount = _itemsCount;

        var startIndex = range.Start.GetOffset(itemsCount);
        var endIndex = range.End.GetOffset(itemsCount);

        SequenceExceptions.ThrowIfRangeInvalid(startIndex, endIndex, itemsCount);

        return new ReadOnlyMemory<T>(_items, startIndex, endIndex - startIndex);
    }
}
