using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T First<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.IFirstOperator @operator
            ? @operator.First()
            : sequence.AsEnumerable().First();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? FirstOrDefault<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.IFirstOperator @operator
            ? @operator.FirstOrDefault()
            : sequence.AsEnumerable().FirstOrDefault();
    }
}
