using BenchmarkDotNet.Running;
using System;

namespace Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyBenchmark>();
            Console.ReadLine();
        }
    }
}
