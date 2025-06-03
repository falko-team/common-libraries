using System.Buffers;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Collections;

namespace Falko.Common.Sequences;

public ref partial struct ValueSequence<T> : ISequence<T>, IDisposable
{
    private const int MinimumCapacity = 64;

    private T[] _values;

    private ref T _valuesRef;

    private int _count;

    private int _capacity;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueSequence()
    {
        _capacity = MinimumCapacity;

        var values = ArrayPool<T>.Shared.Rent(MinimumCapacity);
        _values = values;

        _valuesRef = ref MemoryMarshal.GetArrayDataReference(values);

        _count = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueSequence(int capacity)
    {
        capacity = GetInitialCapacity(capacity);
        _capacity = capacity;

        var values = ArrayPool<T>.Shared.Rent(capacity);
        _values = values;

        _valuesRef = ref MemoryMarshal.GetArrayDataReference(values);

        _count = 0;
    }

    public int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _count;
    }

    public int Capacity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _capacity;
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (uint)index < _count
            ? Unsafe.Add(ref _valuesRef, index)
            : throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(T value)
    {
        if ((uint)_count < _capacity)
        {
            var nextIndex = _count++;

            Unsafe.Add(ref _valuesRef, nextIndex) = value;
        }
        else
        {
            Recapture();

            var nextIndex = _count++;

            Unsafe.Add(ref _valuesRef, nextIndex) = value;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int index, T value)
    {
        if ((uint)index >= _capacity)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        Unsafe.Add(ref _valuesRef, index) = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueEnumerator GetEnumerator() => new(ref _valuesRef, _count);

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public IParallelEnumerator<T> GetParallelEnumerator()
    {
        throw new NotImplementedException();
    }

    private static int GetInitialCapacity(int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity, nameof(capacity));

        return Math.Max(MinimumCapacity, capacity);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        ArrayPool<T>.Shared.Return(_values, true);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Recapture()
    {
        var nextCapacity = Math.Max(_capacity * 2, MinimumCapacity);
        var nextValues = ArrayPool<T>.Shared.Rent(nextCapacity);

        Array.Copy(_values, nextValues, _count);

        ArrayPool<T>.Shared.Return(_values, true);

        _values = nextValues;
        _valuesRef = ref MemoryMarshal.GetArrayDataReference(nextValues);

        _capacity = nextCapacity;
    }
}
