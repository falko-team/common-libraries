using System.Numerics;
using System.Runtime.CompilerServices;
using Original = System;

namespace Falko.Common.Asserts;

public static partial class Return
{
    public static class ArgumentOutOfRangeException
    {
        public static T ThrowIfEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IEquatable<T>?
        {
            Original.ArgumentOutOfRangeException.ThrowIfEqual(value, other, paramName);

            return value;
        }

        public static T ThrowIfNotEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IEquatable<T>?
        {
            Original.ArgumentOutOfRangeException.ThrowIfNotEqual(value, other, paramName);

            return value;
        }

        public static T ThrowIfGreaterThan<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
            Original.ArgumentOutOfRangeException.ThrowIfGreaterThan(value, other, paramName);

            return value;
        }

        public static T ThrowIfGreaterThanOrEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
            Original.ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(value, other, paramName);

            return value;
        }

        public static T ThrowIfLessThan<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
            Original.ArgumentOutOfRangeException.ThrowIfLessThan(value, other, paramName);

            return value;
        }

        public static T ThrowIfLessThanOrEqual<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparable<T>
        {
            Original.ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, other, paramName);

            return value;
        }

        public static T ThrowIfZero<T>(T value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : INumberBase<T>
        {
            Original.ArgumentOutOfRangeException.ThrowIfZero(value, paramName);

            return value;
        }

        public static T ThrowIfNegative<T>(T value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : INumberBase<T>
        {
            Original.ArgumentOutOfRangeException.ThrowIfNegative(value, paramName);

            return value;
        }

        public static T ThrowIfNegativeOrZero<T>(T value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : INumberBase<T>
        {
            Original.ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value, paramName);

            return value;
        }

        public static T ThrowIfPositive<T>(T value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : INumberBase<T>
        {
            if (T.IsPositive(value))
            {
                throw new Original.ArgumentOutOfRangeException(paramName, value, "Value must be positive.");
            }

            return value;
        }

        public static T ThrowIfPositiveOrZero<T>(T value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : INumberBase<T>
        {
            if (T.IsZero(value) || T.IsPositive(value))
            {
                throw new Original.ArgumentOutOfRangeException(paramName, value, "Value must be positive or zero.");
            }

            return value;
        }
    }
}
