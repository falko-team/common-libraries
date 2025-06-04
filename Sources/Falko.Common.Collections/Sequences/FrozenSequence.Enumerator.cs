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
            _currentIndex = -1;

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() { }
    }
}
