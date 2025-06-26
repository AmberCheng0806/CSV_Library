using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Write
{
    internal class HeaderNotExistAndDataExist<T> : AWrite<T>
    {
        public override void Write(string path, List<T> models, string header)
        {
            string Text = File.ReadAllText(path);
            StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine(header);
            writer.Write(Text);
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
