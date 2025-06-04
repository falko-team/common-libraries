using System.Runtime.CompilerServices;
using Falko.Common.Utils;

namespace Falko.Common.Sequences;

public static partial class FrozenSequence
{
    /// <summary>
    /// Copy the given <paramref name="enumerable"/> to a new <see cref="Falko.Common.Collections.FrozenSequence{T}"/>.
    /// </summary>
    /// <param name="enumerable">The enumerable to copy.</param>
    /// <typeparam name="T">The type of the elements in the enumerable.</typeparam>
    /// <returns>A new <see cref="Falko.Common.Collections.FrozenSequence{T}"/> containing the elements of the given <paramref name="enumerable"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(IEnumerable<T> enumerable)
    {
        ArgumentNullException.ThrowIfNull(enumerable);

        if (enumerable is FrozenSequence<T> frozenSequence) return frozenSequence;

        var items = enumerable.ToArray();
        var itemsLength = items.Length;

        return itemsLength is not 0
            ? new FrozenSequence<T>(items, itemsLength)
            : EmptyCache<T>.Instance;
    }

    /// <summary>
    /// Copy the given <paramref name="collection"/> to a new <see cref="Falko.Common.Collections.FrozenSequence{T}"/>.
    /// </summary>
    /// <param name="collection">The collection to copy.</param>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <returns>A new <see cref="Falko.Common.Collections.FrozenSequence{T}"/> containing the elements of the given <paramref name="collection"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(IReadOnlyCollection<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        if (collection.Count is 0) return EmptyCache<T>.Instance;

        if (collection is FrozenSequence<T> frozenSequence) return frozenSequence;

        var items = collection.ToArray();
        var itemsLength = items.Length;

        return itemsLength is 0
            ? EmptyCache<T>.Instance
            : new FrozenSequence<T>(items, itemsLength);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(scoped Span<T> span)
    {
        if (span.IsEmpty) return EmptyCache<T>.Instance;

        var itemsCount = span.Length;

        var itemsBuffer = new T[itemsCount];

        span.CopyTo(SpanMarshal.AsSpan(itemsBuffer, itemsCount));

        return new FrozenSequence<T>(itemsBuffer, itemsCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(scoped ReadOnlySpan<T> span)
    {
        if (span.IsEmpty) return EmptyCache<T>.Instance;

        var itemsCount = span.Length;

        var itemsBuffer = new T[itemsCount];

        span.CopyTo(SpanMarshal.AsSpan(itemsBuffer, itemsCount));

        return new FrozenSequence<T>(itemsBuffer, itemsCount);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(scoped in Memory<T> memory)
    {
        return Copy(memory.Span);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(scoped in ReadOnlyMemory<T> memory)
    {
        return Copy(memory.Span);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(scoped in T[] array)
    {
        ArgumentNullException.ThrowIfNull(array);

        return Copy(new ReadOnlySpan<T>(array));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Copy<T>(scoped in ArraySegment<T> segment)
    {
        return Copy(new ReadOnlySpan<T>(segment.Array, segment.Offset, segment.Count));
    }
}
