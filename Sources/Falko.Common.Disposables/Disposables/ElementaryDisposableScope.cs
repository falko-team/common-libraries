using Falko.Common.Sequences;

namespace Falko.Common.Disposables;

public abstract class ElementaryDisposableScope : IDisposableScope
{
    private const int IsAlreadyDisposed = 1;

    private const int IsNotDisposed = 0;

#if NET9_0_OR_GREATER
    private Lock _locker = new();
#else
    private object _locker = new();
#endif

    // ReSharper disable InconsistentlySynchronizedField
    private Sequence<IAsyncDisposable> _asyncDisposables = new();

    private volatile int _disposed = IsNotDisposed;

    public void Register(IAsyncDisposable asyncDisposable)
    {
        if (_disposed == IsAlreadyDisposed)
        {
            asyncDisposable
                .DisposeAsync()
                .AsTask()
                .Wait();

            return;
        }

        lock (_locker)
        {
            _asyncDisposables.Add(asyncDisposable);
        }
    }

    public async ValueTask DisposeAsync()
    {
        var disposed = _disposed;

        if (disposed == IsAlreadyDisposed)
        {
            return;
        }

        if (Interlocked.CompareExchange(ref _disposed, IsAlreadyDisposed, disposed) == IsAlreadyDisposed)
        {
            return;
        }

        try
        {
            await DisposeAsync(_asyncDisposables);
        }
        finally
        {
            _locker = null!;
            _asyncDisposables = null!;
        }
    }

    protected abstract ValueTask DisposeAsync(Sequence<IAsyncDisposable> asyncDisposables);
}
