using System.Runtime.CompilerServices;

namespace Falko.Concurrents.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Handles and intercepts the successful task and executes the provided function.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The function to execute when the task is successful.</param>
    /// <typeparam name="TIn">The type of the input.</typeparam>
    /// <typeparam name="TOut">The type of the result.</typeparam>
    /// <returns>A task that represents the continuation of the successful task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TOut> InterceptOnSuccess<TIn, TOut>(this Task<TIn> task, Func<TIn, TOut> @do)
    {
        return task.ContinueWith<TOut>
        (
            continuationFunction: (context, state) => Unsafe.As<Func<TIn, TOut>>(state!)(context.Result),
            state: @do,
            continuationOptions: TaskSuccessOptions
        );
    }

    /// <summary>
    /// Handles and intercepts the successful task and executes the provided function.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The function to execute when the task is successful.</param>
    /// <typeparam name="TOut">The type of the result.</typeparam>
    /// <returns>A task that represents the continuation of the successful task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TOut> InterceptOnSuccess<TOut>(this Task task, Func<TOut> @do)
    {
        return task.ContinueWith<TOut>
        (
            continuationFunction: (_, state) => Unsafe.As<Func<TOut>>(state!)(),
            state: @do,
            continuationOptions: TaskSuccessOptions
        );
    }
}
