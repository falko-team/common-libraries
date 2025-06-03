using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Falko.Common.Asserts;

internal static class SequenceExceptions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfEmpty(int count)
    {
        if (count is 0)
        {
            throw new InvalidOperationException("The source sequence is empty.");
        }
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowEmpty()
    {
        throw new InvalidOperationException("The source sequence is empty.");
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowPredicateNull()
    {
        // ReSharper disable once NotResolvedInText
        throw new ArgumentNullException("predicate", "The predicate cannot be null.");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfIndexOutOfRange(int startIndex, int count)
    {
        if ((uint)startIndex > count)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out of range.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfRangeOutOfBounds(int startIndex, int length, int count)
    {
        if ((uint)startIndex > count || (uint)length > count - startIndex)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index or length is out of range.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfRangeInvalid(int startIndex, int endIndex, int count)
    {
        if ((uint)endIndex > (uint)count || (uint)startIndex > (uint)endIndex)
        {
            // ReSharper disable once NotResolvedInText
            throw new ArgumentOutOfRangeException("range", "Range is out of bounds.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNotSingle(int count)
    {
        if (count is not 1)
        {
            throw new InvalidOperationException("The source sequence contains more than one element or is empty.");
        }
    }

    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowNotMatchAny()
    {
        throw new InvalidOperationException("The source sequence does not match any of the specified conditions.");
    }
}
