using System.Runtime.CompilerServices;

namespace Falko.Common.Tasks;

public static partial class ValueTaskExtensions
{
    /// <summary>
    /// Converts the specified <see cref="Task"/> to a <see cref="ValueTask"/>.
    /// </summary>
    /// <param name="task">The task to convert.</param>
    /// <returns>The converted <see cref="ValueTask"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask AsValueTask(this Task task) => new(task);
}
