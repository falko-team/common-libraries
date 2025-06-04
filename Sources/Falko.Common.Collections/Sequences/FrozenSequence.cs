using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Falko.Common.Collections;

namespace Falko.Common.Sequences;

/// <summary>
/// Represents a thread-safe, immutable sequence of elements.
/// </summary>
/// <typeparam name="T">The type of the elements in the sequence.</typeparam>
[DebuggerDisplay("Count = {Count}")]
public partial class FrozenSequence<T> : IReadOnlySequence<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal FrozenSequence(T[] items, int itemsCount) => (_items, _itemsCount) = (items, itemsCount);

    private readonly T[] _items;

    private readonly int _itemsCount;

    /// <summary>
    /// Gets the number of elements in the sequence.
    /// </summary>
    public int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _itemsCount;
    }

    /// <summary>
    /// Gets the element of the sequence at the specified index.
    /// </summary>
    /// <remarks>
    /// Use the <see cref="AsIndexer"/> method to access elements by index faster,
    /// if you need to access elements by index multiple times.
    /// </remarks>
    /// <param name="index">The zero-based index of the element to get.</param>
    /// <exception cref="IndexOutOfRangeException">The index is out of range.</exception>
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _items[index];
    }

    /// <summary>
    /// Gets an enumerator that iterates through the sequence from the beginning to the end.
    /// </summary>
    /// <remarks>
    /// Use the <see cref="AsEnumerable"/> method to iterate in asynchronous code.
    /// </remarks>
    /// <returns>An enumerator that can be used to iterate through the sequence.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueEnumerator GetEnumerator() => new(_items, _itemsCount);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(_items, _itemsCount);

    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(_items, _itemsCount);

    public IParallelEnumerator<T> GetParallelEnumerator() => new ParallelEnumerator(_items, _itemsCount);

    public override string ToString() => $"[{string.Join(", ", _items)}]";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FrozenSequence<T>(T item) => new([item], 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator FrozenSequence<T>(T[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        return new FrozenSequence<T>(items, items.Length);
    }
}
