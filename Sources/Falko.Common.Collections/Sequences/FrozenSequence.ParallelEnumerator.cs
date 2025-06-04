using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Falko.Common.Collections;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T>
{
    private sealed class ParallelEnumerator : IParallelEnumerator<T>
    {
        private readonly T[] _items;
        private readonly int _itemsCount;

        private int _lastItemIndex = -1;

        // ReSharper disable once ConvertToPrimaryConstructor
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ParallelEnumerator(T[] items, int itemsCount)
        {
            _items = items;
            _itemsCount = itemsCount;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryMoveNext([MaybeNullWhen(false)] out T item)
        {
            var currentItemIndex = Interlocked.Increment(ref _lastItemIndex);

            if (currentItemIndex < _itemsCount)
            {
                item = _items[currentItemIndex];
                return true;
            }

            item = default;
            return false;
        }
    }
}
