using System.Runtime.CompilerServices;
using Original = System;

namespace Falko.Common.Asserts;

// ReSharper disable RedundantNameQualifier
public static partial class Return
{
    public static class ArgumentNullException
    {
        public static T ThrowIfNull<T>(T value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            Original.ArgumentNullException.ThrowIfNull(value, paramName);

            return value;
        }

        public static string ThrowIfNullOrWhiteSpace(string? value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            Original.ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);

            return value;
        }

        public static string ThrowIfNullOrEmpty(string? value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            Original.ArgumentException.ThrowIfNullOrEmpty(value, paramName);

            return value;
        }
    }
}
