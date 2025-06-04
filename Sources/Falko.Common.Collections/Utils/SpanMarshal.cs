using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Falko.Common.Utils;

internal static class SpanMarshal
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<T> AsSpan<T>(T[] array, int length)
    {
        return MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(array), length);
    }
}
