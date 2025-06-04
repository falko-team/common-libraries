using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Utils;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IToArrayOperator
{
    public T[] ToArray()
    {
        var itemsCount = _itemsCount;

        if (itemsCount is 0) return [];

        var itemsBuffer = new T[itemsCount];

        AsSpan().CopyTo(SpanMarshal.AsSpan(itemsBuffer, itemsCount));

        return itemsBuffer;
    }

    public T[] ToArray(int startIndex)
    {
        scoped var itemsSpan = AsSpan(startIndex);

        var itemsCount = itemsSpan.Length;

        if (itemsCount is 0) return [];

        var itemsBuffer = new T[itemsCount];

        itemsSpan.CopyTo(SpanMarshal.AsSpan(itemsBuffer, itemsCount));

        return itemsBuffer;
    }

    public T[] ToArray(int startIndex, int length)
    {
        scoped var itemsSpan = AsSpan(startIndex, length);

        var itemsCount = itemsSpan.Length;

        if (itemsCount is 0) return [];

        var itemsBuffer = new T[itemsCount];

        itemsSpan.CopyTo(SpanMarshal.AsSpan(itemsBuffer, itemsCount));

        return itemsBuffer;
    }

    public T[] ToArray(Index startIndex)
    {
        scoped var itemsSpan = AsSpan(startIndex);

        var itemsCount = itemsSpan.Length;

        if (itemsCount is 0) return [];

        var itemsBuffer = new T[itemsCount];

        itemsSpan.CopyTo(SpanMarshal.AsSpan(itemsBuffer, itemsCount));

        return itemsBuffer;
    }

    public T[] ToArray(Range range)
    {
        scoped var itemsSpan = AsSpan(range);

        var itemsCount = itemsSpan.Length;

        if (itemsCount is 0) return [];

        var itemsBuffer = new T[itemsCount];

        itemsSpan.CopyTo(SpanMarshal.AsSpan(itemsBuffer, itemsCount));

        return itemsBuffer;
    }
}
