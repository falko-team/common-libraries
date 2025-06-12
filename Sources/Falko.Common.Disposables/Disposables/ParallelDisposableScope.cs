using Falko.Common.Extensions;
using Falko.Common.Sequences;

namespace Falko.Common.Disposables;

public sealed class ParallelDisposableScope : ElementaryDisposableScope
{
    protected override ValueTask DisposeAsync(Sequence<IAsyncDisposable> asyncDisposables)
    {
        return Parallel
            .ForEachAsync
            (
                source: asyncDisposables,
                body: static (asyncDisposable, _) => asyncDisposable.DisposeAsync()
            )
            .AsValueTask();
    }
}
