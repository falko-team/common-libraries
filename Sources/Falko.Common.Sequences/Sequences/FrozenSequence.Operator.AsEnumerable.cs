using System.Runtime.CompilerServices;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IAsEnumerableOperator<FrozenSequence<T>.Enumerable>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Enumerable AsEnumerable() => new(_items, _itemsCount);
}
