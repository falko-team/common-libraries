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

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item) is false) continue;

            for (++itemIndex; itemIndex < itemsCount; itemIndex++)
            {
                var checkingItem = Unsafe.Add(ref itemsReference, itemIndex);

                if (predicate(checkingItem) is false) continue;

                SequenceExceptions.ThrowNotSingle();
                return default!; // This line is unreachable
            }

            return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Single(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex) is false) continue;

            for (++itemIndex; itemIndex < itemsCount; itemIndex++)
            {
                if (predicate(Unsafe.Add(ref itemsReference, itemIndex), itemIndex) is false) continue;

                SequenceExceptions.ThrowNotSingle();
                return default!; // This line is unreachable
            }

            return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T Single<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument) is false) continue;

            for (++itemIndex; itemIndex < itemsCount; itemIndex++)
            {
                if (predicate(Unsafe.Add(ref itemsReference, itemIndex), argument) is false) continue;

                SequenceExceptions.ThrowNotSingle();
                return default!; // This line is unreachable
            }

            return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
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

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item) is false) continue;

            for (++itemIndex; itemIndex < itemsCount; itemIndex++)
            {
                if (predicate(Unsafe.Add(ref itemsReference, itemIndex)) is false) continue;

                return default;
            }

            return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? SingleOrDefault(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex) is false) continue;

            for (++itemIndex; itemIndex < itemsCount; itemIndex++)
            {
                if (predicate(Unsafe.Add(ref itemsReference, itemIndex), itemIndex) is false) continue;

                return default;
            }

            return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? SingleOrDefault<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument) is false) continue;

            for (++itemIndex; itemIndex < itemsCount; itemIndex++)
            {
                if (predicate(Unsafe.Add(ref itemsReference, itemIndex), argument) is false) continue;

                return default;
            }

            return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? SingleOrDefault<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex, argument) is false) continue;

            for (++itemIndex; itemIndex < itemsCount; itemIndex++)
            {
                if (predicate(Unsafe.Add(ref itemsReference, itemIndex), itemIndex, argument) is false) continue;

                return default;
            }

            return item;
        }

        return default;
    }
}
