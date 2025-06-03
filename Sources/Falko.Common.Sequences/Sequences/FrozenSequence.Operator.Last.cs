using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Asserts;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.ILastOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Last()
    {
        var itemsCount = _itemsCount;

        SequenceExceptions.ThrowIfEmpty(itemsCount);

        return _items[itemsCount - 1];
    }

    public T Last(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var itemsCount = _itemsCount;

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? LastOrDefault()
    {
        var itemsCount = _itemsCount;

        return itemsCount is 0
            ? default
            : _items[itemsCount - 1];
    }

    public T? LastOrDefault(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var itemsCount = _itemsCount;

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item)) return item;
        }

        return default;
    }
}
