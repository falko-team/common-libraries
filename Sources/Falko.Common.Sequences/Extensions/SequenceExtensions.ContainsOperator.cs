using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains<T>(this IReadOnlySequence<T> sequence, T value)
    {
        return sequence is SequenceOperator<T>.IContainsOperator @operator
            ? @operator.Contains(value)
            : sequence.AsEnumerable().Contains(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains<T>(this IReadOnlySequence<T> sequence, T value, IEqualityComparer<T> comparer)
    {
        return sequence is SequenceOperator<T>.IContainsOperator @operator
            ? @operator.Contains(value, comparer)
            : sequence.AsEnumerable().Contains(value, comparer);
    }
}
