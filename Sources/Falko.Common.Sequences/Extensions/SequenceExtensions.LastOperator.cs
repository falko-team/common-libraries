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
    public static T? LastOrDefault<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.ILastOperator @operator
            ? @operator.LastOrDefault()
            : sequence.AsEnumerable().LastOrDefault();
    }
}
