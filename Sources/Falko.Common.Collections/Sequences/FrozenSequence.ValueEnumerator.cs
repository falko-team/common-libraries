using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T>
{
    public ref struct ValueEnumerator
    {
        private readonly ref T _valuesReference;

        private readonly int _valuesCount;

        private int _currentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ValueEnumerator(T[] values, int valuesCount)
        {
            _currentIndex = -1;

            _valuesReference = ref MemoryMarshal.GetArrayDataReference(values);
            _valuesCount = valuesCount;
        }

        public ref readonly T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref Unsafe.Add(ref _valuesReference, _currentIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var nextIndex = _currentIndex + 1;

            if (nextIndex >= _valuesCount) return false;

            _currentIndex = nextIndex;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}
