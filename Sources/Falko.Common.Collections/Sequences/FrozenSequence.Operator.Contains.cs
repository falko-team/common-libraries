using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IContainsOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(T value)
    {
        return Contains(value, EqualityComparer<T>.Default);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Contains(T value, IEqualityComparer<T> comparer)
    {
        var itemsCount = _itemsCount;

        if (itemsCount is 0) return false;

        ArgumentNullException.ThrowIfNull(comparer);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);

        for (var index = 0; index < itemsCount; index++)
        {
            var item = Unsafe.Add(ref itemsReference, index);

            if (comparer.Equals(item, value)) return true;
        }

        return false;
    }
}
