using System.Runtime.CompilerServices;

namespace Falko.Concurrents.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Handles and intercepts the faulted task and executes the provided function.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The function to execute when the task is faulted.</param>
    /// <typeparam name="TOut">The type of the result.</typeparam>
    /// <returns>A task that represents the continuation of the faulted task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TOut> InterceptOnFault<TOut>(this Task task, Func<AggregateException?, TOut> @do)
    {
        return task.ContinueWith<TOut>
        (
            continuationFunction: (context, state) => Unsafe.As<Func<AggregateException?, TOut>>(state!)(context.Exception),
            state: @do,
            continuationOptions: TaskFaultOptions
        );
    }

    /// <summary>
    /// Handles and intercepts the faulted task and executes the provided function.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The function to execute when the task is faulted.</param>
    /// <typeparam name="TOut">The type of the result.</typeparam>
    /// <returns>A task that represents the continuation of the faulted task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TOut> InterceptOnFault<TOut>(this Task task, Func<TOut> @do)
    {
        return task.ContinueWith<TOut>
        (
            continuationFunction: (_, state) => Unsafe.As<Func<TOut>>(state!)(),
            state: @do,
            continuationOptions: TaskFaultOptions
        );
    }
}
