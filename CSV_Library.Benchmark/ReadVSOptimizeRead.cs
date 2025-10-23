using BenchmarkDotNet.Attributes;
using Microsoft.Diagnostics.Tracing.Parsers.JScript;
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
    public class ReadVSOptimizeRead
    {
        static string input = "32,Elizabeth,Kinneally,ekinneallyv@theglobeandmail.com,Genderqueer,159.108.245.113";
        static PropertyInfo[] dtoInfos = typeof(Data).GetProperties();
        static int PropsCount = dtoInfos.Length;


        //委派(delegate)
        delegate void SetterDelegate(object target, object value);
        static SetterDelegate[] Setters = dtoInfos.Select(x => CreateSetter(x)).ToArray();
        static SetterDelegate CreateSetter(PropertyInfo propertyInfo)
        {
            var targetParam = Expression.Parameter(typeof(object));
            var valueParam = Expression.Parameter(typeof(object));

            Expression castTarget = Expression.Convert(targetParam, propertyInfo.DeclaringType);
            Expression castValue = Expression.Convert(valueParam, propertyInfo.PropertyType);

            MethodCallExpression methodCallExpression = Expression.Call(castTarget, propertyInfo.GetSetMethod(), castValue);

            var expression = Expression.Lambda<SetterDelegate>(methodCallExpression, targetParam, valueParam);
            return expression.Compile();
        }


        //委派(delegate)

        //static Action<object, object>[] SetterActions = dtoInfos.Select(x => CreateSetter(x)).ToArray();
        //static Action<object, object> CreateSetter(PropertyInfo propertyInfo)
        //{
        //    var targetParam = Expression.Parameter(typeof(object));
        //    var valueParam = Expression.Parameter(typeof(object));

        //    Expression castTarget = Expression.Convert(targetParam, propertyInfo.DeclaringType);
        //    Expression castValue = Expression.Convert(valueParam, propertyInfo.PropertyType);

        //    MethodCallExpression methodCallExpression = Expression.Call(castTarget, propertyInfo.GetSetMethod(), castValue);

        //    var expression = Expression.Lambda<Action<object, object>>(methodCallExpression, targetParam, valueParam);
        //    return expression.Compile();
        //}



        [Benchmark]
        public void Read()
        {
            List<Data> list = new List<Data>();

            string[] datas = input.Split(',');

            Data data = new Data();
            PropertyInfo[] dtoInfos = typeof(Data).GetProperties();
            for (int i = 0; i < dtoInfos.Length; i++)
            {
                dtoInfos[i].SetValue(data, datas[i]);
            }

            list.Add(data);
        }


        //[Benchmark]
        //public void OptimizeActionRead()
        //{
        //    List<Data> list = new List<Data>();

        //    ReadOnlySpan<char> strings = input.AsSpan();
        //    int current = 0;
        //    int field = 0;
        //    Data data = new Data();

        //    while (true)
        //    {
        //        int num = strings.Slice(current).IndexOf(',');
        //        if (num == -1)
        //        {
        //            SetterActions[field++].Invoke(data, strings.Slice(current).ToString());
        //            break;
        //        }
        //        else
        //        {
        //            SetterActions[field++].Invoke(data, strings.Slice(current, num).ToString());
        //            current += num + 1;
        //        }

        //    }


        //    list.Add(data);

        //}


        [Benchmark]
        public void OptimizeRead()
        {
            List<Data> list = new List<Data>();

            ReadOnlySpan<char> strings = input.AsSpan();
            int current = 0;
            int field = 0;
            Data data = new Data();

            while (true)
            {
                int num = strings.Slice(current).IndexOf(',');
                if (num == -1)
                {
                    Setters[field++].Invoke(data, strings.Slice(current).ToString());
                    break;
                }
                else
                {
                    Setters[field++].Invoke(data, strings.Slice(current, num).ToString());
                    current += num + 1;
                }

            }


            list.Add(data);

        }




    }
}