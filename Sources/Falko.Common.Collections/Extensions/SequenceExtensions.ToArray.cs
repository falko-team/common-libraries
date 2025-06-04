using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToArray<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.IToArrayOperator @operator
            ? @operator.ToArray()
            : sequence.AsEnumerable().ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToArray<T>(this IReadOnlySequence<T> sequence, int startIndex, int length)
    {
        return sequence is SequenceOperator<T>.IToArrayOperator @operator
            ? @operator.ToArray(startIndex, length)
            : sequence.AsEnumerable().Skip(startIndex).Take(length).ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToArray<T>(this IReadOnlySequence<T> sequence, int startIndex)
    {
        return sequence is SequenceOperator<T>.IToArrayOperator @operator
            ? @operator.ToArray(startIndex)
            : sequence.AsEnumerable().Skip(startIndex).ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToArray<T>(this IReadOnlySequence<T> sequence, Index startIndex)
    {
        return sequence is SequenceOperator<T>.IToArrayOperator @operator
            ? @operator.ToArray(startIndex)
            : sequence.AsEnumerable().Skip(startIndex.GetOffset(sequence.Count)).ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToArray<T>(this IReadOnlySequence<T> sequence, Range range)
    {
        if (sequence is SequenceOperator<T>.IToArrayOperator @operator)
        {
            return @operator.ToArray(range);
        }

        return ToArrayIfNotOperable(sequence, range);
    }

    private static T[] ToArrayIfNotOperable<T>(IReadOnlySequence<T> sequence, Range range)
    {
        var itemsCount = sequence.Count;

        var startIndex = range.Start.GetOffset(itemsCount);
        var endIndex = range.End.GetOffset(itemsCount);

        if ((uint)endIndex > itemsCount || (uint)startIndex > endIndex)
        {
            throw new ArgumentOutOfRangeException(nameof(range), "Range is out of bounds.");
        }

        return sequence.AsEnumerable().Skip(startIndex).Take(endIndex - startIndex).ToArray();
    }
}
