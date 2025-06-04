using System.Runtime.CompilerServices;

namespace Falko.Common.Sequences;

/// <summary>
/// Represents a thread-safe, immutable sequence of elements.
/// </summary>
public static partial class FrozenSequence
{
    /// <summary>
    /// Wraps the specified items into a <see cref="Falko.Common.Collections.FrozenSequence{T}"/>.
    /// </summary>
    /// <param name="items">The items to wrap.</param>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    /// <returns>A new <see cref="Falko.Common.Collections.FrozenSequence{T}"/> containing the specified items.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Wrap<T>(params T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        var itemsCount = items.Length;

        return itemsCount is 0
            ? EmptyCache<T>.Instance
            : new FrozenSequence<T>(items, itemsCount);
    }

    /// <summary>
    /// Wraps the specified item into a <see cref="Falko.Common.Collections.FrozenSequence{T}"/>.
    /// </summary>
    /// <param name="item">The item to wrap.</param>
    /// <typeparam name="T">The type of the element in the sequence.</typeparam>
    /// <returns>A new <see cref="Falko.Common.Collections.FrozenSequence{T}"/> containing the specified item.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FrozenSequence<T> Wrap<T>(T item) => new([item], 1);
}
