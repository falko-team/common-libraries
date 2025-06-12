using System.Collections.Concurrent;

namespace Falko.Common.Collections;

internal sealed partial class ParallelEnumerablePartitioner<T>(IParallelEnumerable<T> parallelEnumerable) : Partitioner<T>
{
    public override bool SupportsDynamicPartitions => true;

    public override IList<IEnumerator<T>> GetPartitions(int partitionCount) => throw new NotSupportedException();

    public override IEnumerable<T> GetDynamicPartitions() => new Enumerable(parallelEnumerable.GetParallelEnumerator());
}
