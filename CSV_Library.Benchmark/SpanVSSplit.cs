using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Benchmark
{
    public class SpanVSSplit
    {
        static string date = "2022-04-15";
        [Benchmark]
        public void Split()
        {
            var y = date.Split('-')[0];
            var m = date.Split('-')[1];
            var d = date.Split('-')[2];


        }

        [Benchmark]
        public void Span()
        {
            ReadOnlySpan<char> nameAsSpan = date.AsSpan();

            var y = nameAsSpan.Slice(0, 4);
            var m = nameAsSpan.Slice(5, 2);
            var d = nameAsSpan.Slice(8);


        }
    }
}
