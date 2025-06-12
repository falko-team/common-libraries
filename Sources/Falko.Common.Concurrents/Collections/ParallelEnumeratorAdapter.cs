using System.Collections;
using System.Runtime.CompilerServices;

namespace Falko.Common.Collections;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ParallelEnumeratorAdapter<T>(IParallelEnumerator<T> parallelEnumerator) : IEnumerator<T>
{
    private T? _current;

    public T Current
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _current!;
    }

    object IEnumerator.Current
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _current!;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        if (parallelEnumerator.TryMoveNext(out var current) is false) return false;

        _current = current;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() => throw new NotSupportedException();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose() { }
}
