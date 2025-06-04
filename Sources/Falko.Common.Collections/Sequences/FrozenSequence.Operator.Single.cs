using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Asserts;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.ISingleOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Single()
    {
        SequenceExceptions.ThrowIfNotSingle(_itemsCount);

        return _items[0];
    }

    public T Single(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        T singleItem;

        var itemIndex = 0;

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item) is false) continue;

            singleItem = item;

            ++itemIndex;

            goto CheckRest;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable

        CheckRest:

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item) is false) continue;

            SequenceExceptions.ThrowNotMatchAny();
            return default!; // This line is unreachable
        }

        return singleItem;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? SingleOrDefault()
    {
        return _itemsCount is 1
            ? _items[0]
            : default;
    }

    public T? SingleOrDefault(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        T singleItem;

        var itemIndex = 0;

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item) is false) continue;

            singleItem = item;

            ++itemIndex;

            goto CheckRest;
        }

        return default;

        CheckRest:

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item)) return default;
        }

        return singleItem;
    }
}
