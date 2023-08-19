``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1848/22H2/2022Update/SunValley2)
12th Gen Intel Core i9-12900K, 1 CPU, 24 logical and 16 physical cores
.NET SDK=6.0.400
  [Host]     : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.8 (6.0.822.36306), X64 RyuJIT AVX2


```
|         Method |      Mean |     Error |    StdDev |    Median | Rank | Allocated |
|--------------- |----------:|----------:|----------:|----------:|-----:|----------:|
| BenchPlayVideo |        NA |        NA |        NA |        NA |    ? |         - |
|     ConsoleGay | 0.0010 ns | 0.0022 ns | 0.0020 ns | 0.0001 ns |    1 |         - |

Benchmarks with issues:
  MyBenchmark.BenchPlayVideo: DefaultJob
