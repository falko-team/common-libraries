namespace Falko.Common.Operators;

public static partial class SequenceOperator<T>
{
    public interface IAsEnumerableOperator<out TEnumerable> where TEnumerable : IEnumerable<T>
    {
        TEnumerable AsEnumerable();
    }
}
