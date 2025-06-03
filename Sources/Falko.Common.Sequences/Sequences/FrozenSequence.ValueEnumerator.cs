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
            var currentIndex = _currentIndex;

            if (currentIndex == _valuesCount) return false;

            _currentIndex = currentIndex + 1;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            _currentIndex = 0;
        }
    }
}
