using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Benchmark
{
    [MemoryDiagnoser]
    public class Writer_VS_OptimizeWriter
    {
        static PropertyInfo[] props = typeof(Data).GetProperties();
        delegate object GetterDelegate(object target);
        static GetterDelegate[] Getters = props.Select(x => CreateGetter(x)).ToArray();
        static StringBuilder stringBuilder = new StringBuilder(90);
        static char[] buffer = new char[90];
        static GetterDelegate CreateGetter(PropertyInfo propertyInfo)
        {

            var targetParam = Expression.Parameter(typeof(object));

            var castTarget = Expression.Convert(targetParam, propertyInfo.DeclaringType);
            var body = Expression.Call(castTarget, propertyInfo.GetGetMethod());
            var expression = Expression.Lambda<GetterDelegate>(body, targetParam);  // string name = data.Name
            return expression.Compile();
        }

        [Benchmark]
        public void Writer()
        {
            for (int j = 0; j < 2500000; j++)
            {

                Data data = new Data()
                {
                    Id = "32",
                    FirstName = "Elizabeth",
                    LastName = "Kinneally",
                    Email = "ekinneallyv@theglobeandmail.com",
                    Gender = "Genderqueer",
                    IpAddress = "159.108.245.113"
                };

                string output = "";
                var props = data.GetType().GetProperties();

                foreach (var prop in props)
                {
                    output += prop.GetValue(data) + ",";
                }
                output = output.TrimEnd(',');

            }


        }

        [Benchmark]
        public void OptimizeWriter()
        {
            for (int j = 0; j < 2500000; j++)
            {

                Data data = new Data()
                {
                    Id = "32",
                    FirstName = "Elizabeth",
                    LastName = "Kinneally",
                    Email = "ekinneallyv@theglobeandmail.com",
                    Gender = "Genderqueer",
                    IpAddress = "159.108.245.113"
                };

                for (int i = 0; i < Getters.Length; i++)
                {
                    stringBuilder.Append(Getters[i](data));
                    if (i < Getters.Length - 1)
                        stringBuilder.Append(',');
                }

                stringBuilder.CopyTo(0, buffer, 0, stringBuilder.Length);
                stringBuilder.Clear();
            }


        }

    }
}
