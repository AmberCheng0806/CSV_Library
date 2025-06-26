using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library
{
    internal class HeaderManage
    {
        public static HeaderType CheckHeader<T>(string path, out string header)
        {
            var properties = typeof(T).GetProperties().Select(x => x.Name);
            header = string.Join(",", properties);
            if (!File.Exists(path))
            {
                return HeaderType.FileNotExist;
            }
            StreamReader reader = new StreamReader(path);
            string firstLine = reader.ReadLine();
            reader.Close();
            if (firstLine == null)
            {
                return HeaderType.HeaderNotExistAndDataNotExist;
            }
            if (firstLine != header)
            {
                return HeaderType.HeaderNotExistAndDataExist;
            }
            return HeaderType.HeaderExist;
        }

        public static Dictionary<string, int> HeaderMapping(StreamReader reader)
        {
            string header = reader.ReadLine();
            string[] headerArray = header.Split(',');
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < headerArray.Length; i++)
            {
                dict[headerArray[i]] = i;
            }
            return dict;
        }
    }
}
