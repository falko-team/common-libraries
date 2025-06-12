using System.Collections;
using Falko.Common.Extensions;

namespace Falko.Common.Collections;

internal sealed partial class ParallelEnumerablePartitioner<T>
{
    private sealed class Enumerable(IParallelEnumerator<T> parallelEnumerator) : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator() => parallelEnumerator.ToEnumerable();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
