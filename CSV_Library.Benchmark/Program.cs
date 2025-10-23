using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder stringBuilder = new StringBuilder(90);
            //stringBuilder.Append("32");
            //stringBuilder.Append(",");
            //stringBuilder.Append("Elizabeth");
            //stringBuilder.Append(",");
            //stringBuilder.Append("Kinneally");
            //stringBuilder.Append(",");
            //stringBuilder.Append("ekinneallyv@theglobeandmail.com");
            //stringBuilder.Append(",");
            //stringBuilder.Append("Genderqueer");
            //stringBuilder.Append(",");
            //stringBuilder.Append("159.108.245.113");

            //char[] buffer = new char[90];
            //stringBuilder.CopyTo(0, buffer, 0, stringBuilder.Length);

            //buffer[0] = '9';

            //StreamWriter streamWriter = new StreamWriter("data.csv", true);
            //streamWriter.WriteLine(buffer, 0, stringBuilder.Length);
            //streamWriter.Flush();
            //streamWriter.Close();

            //var summary = BenchmarkRunner.Run<EmptyVSNewList>();
            //var summary = BenchmarkRunner.Run<StringVSNullVSEmpty>();
            //var summary = BenchmarkRunner.Run<CountVSCountFunction>();
            //var summary = BenchmarkRunner.Run<ReadVSOptimizeRead>();
            var summary = BenchmarkRunner.Run<Writer_VS_OptimizeWriter>();

        }
    }
}
