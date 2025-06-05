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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Last(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Last(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Last<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Last<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex, argument)) return item;
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

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? LastOrDefault(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item)) return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? LastOrDefault(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex)) return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? LastOrDefault<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument)) return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? LastOrDefault<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = itemsCount - 1; itemIndex >= 0; itemIndex--)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex, argument)) return item;
        }

        return default;
    }
}
