namespace Falko.Common.Sequences;

public partial class FrozenSequence
{
    /// <summary>
    /// Returns cached empty <see cref="Falko.Common.Sequences.FrozenSequence{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the sequence.</typeparam>
    /// <returns>Returns cached empty <see cref="Falko.Common.Sequences.FrozenSequence{T}"/>.</returns>
    public static FrozenSequence<T> Empty<T>()
    {
        return EmptyCache<T>.Instance;
    }

    private static class EmptyCache<T>
    {
        public static readonly FrozenSequence<T> Instance = new([], 0);
    }
}
