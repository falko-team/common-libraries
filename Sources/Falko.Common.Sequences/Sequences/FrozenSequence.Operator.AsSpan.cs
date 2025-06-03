using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Asserts;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IAsSpanOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsSpan()
    {
        return MemoryMarshal.CreateReadOnlySpan(ref MemoryMarshal.GetArrayDataReference(_items), _itemsCount);
    }

    public ReadOnlySpan<T> AsSpan(int startIndex)
    {
        var itemsCount = _itemsCount;

        SequenceExceptions.ThrowIfIndexOutOfRange(startIndex, itemsCount);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        scoped ref var startReference = ref Unsafe.Add(ref itemsReference, startIndex);

        return MemoryMarshal.CreateReadOnlySpan(ref startReference, itemsCount - startIndex);
    }

    public ReadOnlySpan<T> AsSpan(int startIndex, int length)
    {
        var itemsCount = _itemsCount;

        SequenceExceptions.ThrowIfRangeOutOfBounds(startIndex, length, itemsCount);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        scoped ref var startReference = ref Unsafe.Add(ref itemsReference, startIndex);

        return MemoryMarshal.CreateReadOnlySpan(ref startReference, length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<T> AsSpan(Index startIndex)
    {
        return AsSpan(startIndex.GetOffset(_itemsCount));
    }

    public ReadOnlySpan<T> AsSpan(Range range)
    {
        var itemsCount = _itemsCount;

        var startIndex = range.Start.GetOffset(itemsCount);
        var endIndex = range.End.GetOffset(itemsCount);

        SequenceExceptions.ThrowIfRangeInvalid(startIndex, endIndex, itemsCount);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        scoped ref var startReference = ref Unsafe.Add(ref itemsReference, startIndex);

        return MemoryMarshal.CreateReadOnlySpan(ref startReference, endIndex - startIndex);
    }
}
