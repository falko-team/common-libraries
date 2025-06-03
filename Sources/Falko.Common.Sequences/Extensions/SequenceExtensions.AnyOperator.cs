using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Any<T>(this IReadOnlySequence<T> sequence)
    {
        return sequence is SequenceOperator<T>.IAnyOperator @operator
            ? @operator.Any()
            : sequence.Count > 0;
    }
}
