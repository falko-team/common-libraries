using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Asserts;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IFirstOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T First()
    {
        SequenceExceptions.ThrowIfEmpty(_itemsCount);

        return _items[0];
    }

    public T First(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        foreach (var item in this)
        {
            if (predicate(item)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default!; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? FirstOrDefault()
    {
        return _itemsCount is 0
            ? default
            : _items[0];
    }

    public T? FirstOrDefault(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        foreach (ref readonly var item in this)
        {
            if (predicate(item)) return item;
        }

        return default;
    }
}
