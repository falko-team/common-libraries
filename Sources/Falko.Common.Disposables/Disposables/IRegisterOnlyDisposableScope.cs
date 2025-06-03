namespace Falko.Common.Disposables;

public interface IRegisterOnlyDisposableScope
{
    void Register(IAsyncDisposable asyncDisposable);
}
