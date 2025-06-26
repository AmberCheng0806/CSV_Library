using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Write
{
    internal class HeaderExist<T> : AWrite<T>
    {
        public override void Write(string path, List<T> models, string header)
        {
            StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8);
            foreach (var model in models)
            {
                var values = typeof(T).GetProperties().Select(x => x.GetValue(model).ToString());
                string data = string.Join(",", values);
                writer.WriteLine(data);
            }
            writer.Flush();
            writer.Close();
        }
    }
}
