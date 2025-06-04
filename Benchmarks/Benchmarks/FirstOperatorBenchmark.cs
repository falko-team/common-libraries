using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Falko.Common.Extensions;
using Falko.Common.Sequences;

namespace Benchmarks;

[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net90)]
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.NativeAot90)]
public class FirstOperatorBenchmark
{
    private List<int> _list = null!;

    private FrozenSequence<int> _frozenSequence = null!;

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
            _ = _frozenSequence.First(static number => number is 50);
        }
    }

    [Benchmark]
    public void ListFirst()
    {
        for (var i = 0; i < 3; i++)
        {
            _ = _list.First(static number => number is 50);
        }
    }
}
