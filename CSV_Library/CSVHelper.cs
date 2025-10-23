using CSV_Library.Write;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library
{
    public class CSVHelper
    {
        public static void Write<T>(string path, T dataModel)
        {
            string[] pathes = path.Split('\\');
            string folder = string.Join("\\", pathes.Take(pathes.Length - 1));
            Directory.CreateDirectory(folder);
            string header = "";
            HeaderType headerType = HeaderManage.CheckHeader<T>(path, out header);
            Type type = Type.GetType($"CSV_Library.Write.{headerType.ToString()}`1"); //HeaderExist<T>
            Type genericType = type.MakeGenericType(typeof(T));
            string gT = genericType.FullName;
            string int_List = typeof(List<int>).FullName;
            string string_List = typeof(List<string>).FullName;
            string string_dict = typeof(Dictionary<int, string>).FullName;
            AWrite<T> aWrite = (AWrite<T>)Activator.CreateInstance(genericType);
            aWrite.Write(path, new List<T> { dataModel }, header);
        }

        public static void Write<T>(string path, List<T> modelList)
        {
            string[] pathes = path.Split('\\');
            string folder = string.Join("\\", pathes.Take(pathes.Length - 1));
            Directory.CreateDirectory(folder);
            string header = "";
            HeaderType headerType = HeaderManage.CheckHeader<T>(path, out header);
            AWrite<T> aWrite = WriterFactory.CreateWrite<T>(headerType);
            aWrite.Write(path, modelList, header);
        }

        public static List<T> Read<T>(string path) where T : new()
        {
            if (!path.Split('\\').Last().EndsWith("csv"))
            {
                throw new Exception("檔案格式錯誤");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("檔案不存在");
            }
            List<T> list = new List<T>();
            StreamReader reader = new StreamReader(path);
            Dictionary<string, int> dict = HeaderManage.HeaderMapping(reader);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] split = line.Split(',');
                T obj = new T();
                PropertyInfo[] dtoInfos = typeof(T).GetProperties();
                for (int i = 0; i < dtoInfos.Length; i++)
                {
                    if (!dict.ContainsKey(dtoInfos[i].Name))
                    {
                        continue;
                    }
                    int index = dict[dtoInfos[i].Name];
                    dtoInfos[i].SetValue(obj, split[index]);
                }
                list.Add(obj);
            }
            reader.Close();
            return list;
        }

        public static List<T> Read<T>(string path, int startLine, int takeCount) where T : new()
        {
            if (!path.Split('\\').Last().EndsWith("csv"))
            {
                throw new Exception("檔案格式錯誤");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("檔案不存在");
            }
            List<T> list = new List<T>();
            StreamReader reader = new StreamReader(path);
            Dictionary<string, int> dict = HeaderManage.HeaderMapping(reader);
            int currentLine = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                currentLine++;
                if (currentLine < startLine)
                {
                    continue;
                }
                if (currentLine > startLine + takeCount - 1)
                {
                    break;
                }
                string[] split = line.Split(',');
                T obj = new T();
                PropertyInfo[] dtoInfos = typeof(T).GetProperties();
                for (int i = 0; i < dtoInfos.Length; i++)
                {
                    if (!dict.ContainsKey(dtoInfos[i].Name))
                    {
                        continue;
                    }
                    int index = dict[dtoInfos[i].Name];
                    dtoInfos[i].SetValue(obj, split[index]);
                }
                list.Add(obj);
            }
            reader.Close();
            return list;
        }

        public static void OptimizeWrite<T>(string path, List<T> modelList) { }

        public static List<T> OptimizeRead<T>(string path, int startLine, int takeCount)
        {
            if (!path.Split('\\').Last().EndsWith("csv"))
            {
                throw new Exception("檔案格式錯誤");
            }
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("檔案不存在");
            }
            List<T> list = new List<T>();
            StreamReader reader = new StreamReader(path);
            int currentLine = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                currentLine++;
                if (currentLine < startLine)
                {
                    continue;
                }
                if (currentLine > startLine + takeCount - 1)
                {
                    break;
                }


                ReadOnlySpan<char> lineSpan = line.AsSpan();









                string[] split = line.Split(',');
                T obj = new T();
                PropertyInfo[] dtoInfos = typeof(T).GetProperties();
                for (int i = 0; i < dtoInfos.Length; i++)
                {
                    if (!dict.ContainsKey(dtoInfos[i].Name))
                    {
                        continue;
                    }
                    int index = dict[dtoInfos[i].Name];
                    dtoInfos[i].SetValue(obj, split[index]);
                }
                list.Add(obj);
            }
            reader.Close();
            return list;
        }



    }
}
