using System.Runtime.CompilerServices;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Sequence<T> ToSequence<T>(this IEnumerable<T> values)
    {
        var sequence = new Sequence<T>();

        sequence.AddRange(values);

        return sequence;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Sequence<T> ToSequence<T>(this IReadOnlyCollection<T> values)
    {
        if (values.Count is 0) return [];

        var sequence = new Sequence<T>();

        sequence.AddRange(values);

        return sequence;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Sequence<T> ToSequence<T>(this Sequence<T> values)
    {
        if (values.Count is 0) return [];

        var sequence = new Sequence<T>();

        sequence.AddRange(values);

        return sequence;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Sequence<T> ToSequence<T>(this FrozenSequence<T> values)
    {
        if (values.Count is 0) return [];

        var sequence = new Sequence<T>();

        sequence.AddRange(values);

        return sequence;
    }
}
