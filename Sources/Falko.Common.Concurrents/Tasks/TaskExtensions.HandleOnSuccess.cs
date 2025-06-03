using System.Runtime.CompilerServices;

namespace Falko.Common.Tasks;

public static partial class TaskExtensions
{
    /// <summary>
    /// Handles the successful task and executes the provided action.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The action to execute when the task is successful.</param>
    /// <typeparam name="TIn">The type of the input.</typeparam>
    /// <returns>A task that represents the continuation of the successful task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task HandleOnSuccess<TIn>(this Task<TIn> task, Action<TIn> @do)
    {
        return task.ContinueWith
        (
            continuationAction: (context, state) => Unsafe.As<Action<TIn>>(state!)(context.Result),
            state: @do,
            continuationOptions: TaskSuccessOptions
        );
    }

    /// <summary>
    /// Handles the successful task and executes the provided action.
    /// </summary>
    /// <param name="task">The task to handle.</param>
    /// <param name="do">The action to execute when the task is successful.</param>
    /// <returns>A task that represents the continuation of the successful task.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task HandleOnSuccess(this Task task, Action @do)
    {
        return task.ContinueWith
        (
            continuationAction: (_, state) => Unsafe.As<Action>(state!)(),
            state: @do,
            continuationOptions: TaskSuccessOptions
        );
    }
}
