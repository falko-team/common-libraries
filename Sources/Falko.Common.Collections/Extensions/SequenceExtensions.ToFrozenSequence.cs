using Falko.Common.Sequences;

namespace Falko.Common.Extensions;

public static partial class SequenceExtensions
{
    public static FrozenSequence<T> ToFrozenSequence<T>(this FrozenSequence<T> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        return values;
    }

    public static FrozenSequence<T> ToFrozenSequence<T>(this IEnumerable<T> enumerable)
    {
        return FrozenSequence.Copy(enumerable);
    }

    public static FrozenSequence<T> ToFrozenSequence<T>(this IReadOnlyCollection<T> values)
    {
        return FrozenSequence.Copy(values);
    }

    public static FrozenSequence<T> ToFrozenSequence<T>(this scoped Span<T> values)
    {
        return FrozenSequence.Copy(values);
    }

    public static FrozenSequence<T> ToFrozenSequence<T>(this scoped ReadOnlySpan<T> values)
    {
        return FrozenSequence.Copy(values);
    }

    public static FrozenSequence<T> ToFrozenSequence<T>(this scoped in Memory<T> values)
    {
        return FrozenSequence.Copy(values);
    }

    public static FrozenSequence<T> ToFrozenSequence<T>(this scoped in ReadOnlyMemory<T> values)
    {
        return FrozenSequence.Copy(values);
    }

    public static FrozenSequence<T> ToFrozenSequence<T>(this T[] values)
    {
        return FrozenSequence.Copy(values);
    }
}
