namespace Falko.Common.Extensions;

public static partial class TaskExtensions
{
    private const TaskContinuationOptions TaskFaultOptions =
        TaskContinuationOptions.ExecuteSynchronously |
        TaskContinuationOptions.OnlyOnFaulted;

    private const TaskContinuationOptions TaskSuccessOptions =
        TaskContinuationOptions.ExecuteSynchronously |
        TaskContinuationOptions.OnlyOnRanToCompletion;
}
