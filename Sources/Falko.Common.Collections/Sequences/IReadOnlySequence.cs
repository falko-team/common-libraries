using Falko.Common.Collections;

namespace Falko.Common.Sequences;

public interface IReadOnlySequence<T> : IReadOnlyCollection<T>, IParallelEnumerable<T>;
