using System.Collections;
using System.Runtime.CompilerServices;

namespace Falko.Common.Sequences;

public ref partial struct ValueSequence<T>
{
    public ref struct ValueEnumerator : IEnumerator<T>
    {
        private readonly ref T _valuesReference;

        private readonly int _valuesCount;

        private int _currentIndex;

        private T _currentValue = default!;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ValueEnumerator(ref T valuesReference, int valuesCount)
        {
            _valuesReference = ref valuesReference;
            _valuesCount = valuesCount;
        }

        public T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _currentValue!;
        }

        object IEnumerator.Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _currentValue!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            if (_currentIndex == _valuesCount) return false;

            _currentValue = Unsafe.Add(ref _valuesReference, _currentIndex);

            ++_currentIndex;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            _currentIndex = 0;
            _currentValue = default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() { }
    }
}
