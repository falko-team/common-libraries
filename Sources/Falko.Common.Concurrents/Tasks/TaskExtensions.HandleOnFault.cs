using System.Runtime.CompilerServices;

namespace Falko.Common.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Handles the faulted task and executes the provided action.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The action to execute when the task is faulted.</param>
    /// <returns>A task that represents the continuation of the faulted task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task HandleOnFault(this Task task, Action<AggregateException?> @do)
    {
        return task.ContinueWith
        (
            continuationAction: (context, state) => Unsafe.As<Action<AggregateException?>>(state!)(context.Exception),
            state: @do,
            continuationOptions: TaskFaultOptions
        );
    }

    /// <summary>
    /// Handles the faulted task and executes the provided action.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The action to execute when the task is faulted.</param>
    /// <returns>A task that represents the continuation of the faulted task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task HandleOnFault(this Task task, Action @do)
    {
        return task.ContinueWith
        (
            continuationAction: (_, state) => Unsafe.As<Action>(state!)(),
            state: @do,
            continuationOptions: TaskFaultOptions
        );
    }
}
