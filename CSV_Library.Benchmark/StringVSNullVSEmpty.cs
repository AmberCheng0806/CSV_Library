using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Benchmark
{
    [MemoryDiagnoser]
    public class StringVSNullVSEmpty
    {
        [Benchmark]
        public void String()
        { string strA = ""; }

        [Benchmark]
        public void Empty()
        { string strB = string.Empty; }

        [Benchmark]
        public void Null()
        { string strC = null; }


    }
}
