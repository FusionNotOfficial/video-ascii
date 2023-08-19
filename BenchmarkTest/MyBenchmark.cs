using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ImageConverter;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MyBenchmark
    {
        [Benchmark]
        public void BenchPlayVideo()
        {
            short framecount = ImageConverter.Program.PlayVideo();
            for (short i = 0; i < framecount; i++)
            {
                ImageConverter.Program.PrintFrame(i);
                System.Threading.Thread.Sleep(11);
            }
        }
        [Benchmark]
        public void ConsoleGay()
        {
            int a = 5;
        }
    }
}