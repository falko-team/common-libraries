using Falko.Common.Collections;

namespace Falko.Common.Extensions;

public static partial class ParallelEnumeratorExtensions
{
    public static IEnumerator<T> ToEnumerable<T>(this IParallelEnumerator<T> parallelEnumerator)
    {
        return new ParallelEnumeratorAdapter<T>(parallelEnumerator);
    }
}
