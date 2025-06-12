using Falko.Common.Disposables;

namespace Falko.Common.Extensions;

public static partial class DisposableScopeExtensions
{
    public static void Register(this IRegisterOnlyDisposableScope scope, IDisposable disposable)
    {
        scope.Register(new AsyncDisposableWrapper(disposable));
    }
}

file sealed class AsyncDisposableWrapper(IDisposable disposable) : IAsyncDisposable
{
    public ValueTask DisposeAsync()
    {
        disposable.Dispose();

        return ValueTask.CompletedTask;
    }
}
