using BenchmarkDotNet.Running;
using Benchmarks;

var b = new FirstOperatorBenchmark();
b.Setup();
b.FrozenSequenceFirst();
b.ListFirst();
BenchmarkRunner.Run<FirstOperatorBenchmark>();
