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

    [MethodImpl(MethodImplOptions.NoInlining)]
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Single(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        T singleItem;

        var itemIndex = 0;

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex) is false) continue;

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

            if (predicate(item, itemIndex) is false) continue;

            SequenceExceptions.ThrowNotMatchAny();
            return default!; // This line is unreachable
        }

        return singleItem;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Single<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        T singleItem;

        var itemIndex = 0;

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument) is false) continue;

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

            if (predicate(item, argument) is false) continue;

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

    [MethodImpl(MethodImplOptions.NoInlining)]
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? SingleOrDefault(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        T singleItem;

        var itemIndex = 0;

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex) is false) continue;

            singleItem = item;

            ++itemIndex;

            goto CheckRest;
        }

        return default;

        CheckRest:

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex)) return default;
        }

        return singleItem;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? SingleOrDefault<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        T singleItem;

        var itemIndex = 0;

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument) is false) continue;

            singleItem = item;

            ++itemIndex;

            goto CheckRest;
        }

        return default;

        CheckRest:

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument)) return default;
        }

        return singleItem;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? SingleOrDefault<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        T singleItem;

        var itemIndex = 0;

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex, argument) is false) continue;

            singleItem = item;

            ++itemIndex;

            goto CheckRest;
        }

        return default;

        CheckRest:

        for (; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex, argument)) return default;
        }

        return singleItem;
    }
}
