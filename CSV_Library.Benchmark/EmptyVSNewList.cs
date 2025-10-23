using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Benchmark
{
    [MemoryDiagnoser]
    public class EmptyVSNewList
    {
        // 紅方選手
        [Benchmark]
        public void Empty()
        {
            Enumerable.Empty<Foo>();
        }

        // 藍方選手
        [Benchmark]
        public void NewList()
        {
            new List<Foo>();
        }
    }
}
