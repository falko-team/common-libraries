using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Single<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.ISingleOperator @operator
            ? @operator.Single()
            : sequence.AsEnumerable().Single();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? SingleOrDefault<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.ISingleOperator @operator
            ? @operator.SingleOrDefault()
            : sequence.AsEnumerable().SingleOrDefault();
    }
}
