using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.ILastOperator @operator
            ? @operator.Last()
            : sequence.AsEnumerable().Last();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Last<T>(this IReadOnlySequence<T> sequence, Func<T, bool> predicate)
    {
        return sequence is SequenceOperator<T>.ILastOperator @operator
            ? @operator.Last(predicate)
            : sequence.AsEnumerable().Last(predicate);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.ILastOperator @operator
            ? @operator.LastOrDefault()
            : sequence.AsEnumerable().LastOrDefault();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? LastOrDefault<T>(this IReadOnlySequence<T> sequence, Func<T, bool> predicate)
    {
        return sequence is SequenceOperator<T>.ILastOperator @operator
            ? @operator.LastOrDefault(predicate)
            : sequence.AsEnumerable().LastOrDefault(predicate);
    }
}
