using System.Runtime.CompilerServices;

namespace Falko.Common.Sequences;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public readonly ref struct SequencingAdapter<T>(IEnumerable<T> enumerable)
{
    public readonly IEnumerable<T> Enumerable = enumerable;
}
