using System.Runtime.CompilerServices;

namespace Falko.Common.Sequences;

public partial class Sequence<T>
{
    public sealed class Node
    {
        public readonly T Value;

        public Node? Next;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Node(T value) => Value = value;
    }
}
