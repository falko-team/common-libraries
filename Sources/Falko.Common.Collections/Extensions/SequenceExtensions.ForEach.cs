using System.Runtime.CompilerServices;
using Falko.Common.Operators;
using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEach<T>(this IReadOnlySequence<T> sequence, Action<T> action)
    {
        if (sequence is SequenceOperator<T>.IForEachOperator @operator)
        {
            @operator.ForEach(action);
        }
        else
        {
            ForEach(sequence.AsEnumerable(), action);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEach<T>(this IReadOnlySequence<T> sequence, Action<T, int> action)
    {
        if (sequence is SequenceOperator<T>.IForEachOperator @operator)
        {
            @operator.ForEach(action);
        }
        else
        {
            ForEach(sequence.AsEnumerable(), action);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEach<T, TArgument>
    (
        this IReadOnlySequence<T> sequence,
        TArgument argument,
        Action<T, TArgument> action
    )
    {
        if (sequence is SequenceOperator<T>.IForEachOperator @operator)
        {
            @operator.ForEach(argument, action);
        }
        else
        {
            ForEach(sequence.AsEnumerable(), argument, action);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEach<T, TArgument>
    (
        this IReadOnlySequence<T> sequence,
        TArgument argument,
        Action<T, int, TArgument> action
    )
    {
        if (sequence is SequenceOperator<T>.IForEachOperator @operator)
        {
            @operator.ForEach(argument, action);
        }
        else
        {
            ForEach(sequence.AsEnumerable(), argument, action);
        }
    }

    private static void ForEach<T>(IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var item in enumerable)
        {
            action(item);
        }
    }

    private static void ForEach<T>(IEnumerable<T> enumerable, Action<T, int> action)
    {
        using var enumerator = enumerable.GetEnumerator();

        for (var index = 0; enumerator.MoveNext(); ++index)
        {
            action(enumerator.Current, index);
        }
    }

    private static void ForEach<T, TArgument>
    (
        IEnumerable<T> enumerable,
        TArgument argument,
        Action<T, TArgument> action
    )
    {
        foreach (var item in enumerable)
        {
            action(item, argument);
        }
    }

    private static void ForEach<T, TArgument>
    (
        IEnumerable<T> enumerable,
        TArgument argument,
        Action<T, int, TArgument> action
    )
    {
        using var enumerator = enumerable.GetEnumerator();

        for (var index = 0; enumerator.MoveNext(); ++index)
        {
            action(enumerator.Current, index, argument);
        }
    }
}
