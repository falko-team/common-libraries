using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IForEachOperator
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void ForEach(Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            action(Unsafe.Add(ref itemsReference, itemIndex));
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void ForEach(Action<T, int> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            action(Unsafe.Add(ref itemsReference, itemIndex), itemIndex);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void ForEach<TArgument>(TArgument argument, Action<T, TArgument> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            action(Unsafe.Add(ref itemsReference, itemIndex), argument);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void ForEach<TArgument>(TArgument argument, Action<T, int, TArgument> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            action(Unsafe.Add(ref itemsReference, itemIndex), itemIndex, argument);
        }
    }
}
