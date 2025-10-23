using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Benchmark
{
    [MemoryDiagnoser]
    public class CountVSCountFunction
    {
        [Benchmark]
        public void Count()
        {
            List<int> list = new List<int>();
            int num = list.Count;
        }
        [Benchmark]
        public void CountFun()
        {
            List<int> list = new List<int>();
            int num = list.Count();
        }

    }
}
