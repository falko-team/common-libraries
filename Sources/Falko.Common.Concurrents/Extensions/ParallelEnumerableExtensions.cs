using System.Collections.Concurrent;
using Falko.Common.Collections;

namespace Falko.Common.Extensions;

public static partial class ParallelEnumerableExtensions
{
    public static Partitioner<T> ToPartitioner<T>(this IParallelEnumerable<T> parallelEnumerable)
    {
        return new ParallelEnumerablePartitioner<T>(parallelEnumerable);
    }
}
