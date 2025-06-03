using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T>
{
    public struct Enumerator : IEnumerator<T>
    {
        private readonly T[] _values;

        private readonly int _valuesCount;

        private int _currentIndex;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Enumerator(T[] values, int valuesCount)
        {
            _values = values;
            _valuesCount = valuesCount;
        }

        public T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _values[_currentIndex];
        }

        object? IEnumerator.Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _values[_currentIndex];
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() { }
    }
}
