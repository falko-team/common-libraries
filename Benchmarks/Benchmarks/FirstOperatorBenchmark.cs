using BenchmarkDotNet.Attributes;
using Falko.Common.Extensions;
using Falko.Common.Sequences;

namespace Benchmarks;

public class FirstOperatorBenchmark
{
    private List<int>? _list;

    private FrozenSequence<int>? _frozenSequence;

    [GlobalSetup]
    public void Setup()
    {
        _frozenSequence = Enumerable.Range(0, 100).ToFrozenSequence();

        _list = Enumerable.Range(0, 100).ToList();
    }

    [Benchmark(Baseline = true)]
    public void FrozenSequenceFirst()
    {
        for (var i = 0; i < 3; i++)
        {
            _ = _frozenSequence!.First(number => number is 50);
        }
    }

    [Benchmark]
    public void ListFirst()
    {
        for (var i = 0; i < 3; i++)
        {
            _ = _list!.First(number => number is 50);
        }
    }
}
