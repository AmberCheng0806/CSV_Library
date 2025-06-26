using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //分層架構
            //DAO(Data Access Object) => 掌管資料
            //DTO(Data Transfer Object) => 掌管商業邏輯與多個DAO集合
            //ViewModel => 前端根據後端回傳的內容來進行渲染



            Data data1 = new Data("N", "V", "T", "D", "C");
            Data data2 = new Data("N2", "V2", "T2", "D2", "C2");
            CSVHelper.Write("C:\\Users\\user\\Desktop\\campaigns\\test.csv", data1);
            CSVHelper.Write<Data>("C:\\Users\\user\\Desktop\\campaigns\\test.csv", data2);
            //List<Data> modelList = new List<Data>() { data1, data2 };
            //CSVHelper.Write<Data>("C:\\Users\\user\\Desktop\\campaigns123\\test.csv", modelList);
            List<DataDTO> list = CSVHelper.Read<DataDTO>("C:\\Users\\user\\Desktop\\campaigns\\test.csv");
            foreach (DataDTO data in list)
            {
                Console.WriteLine(data.Name);
            }
            Console.ReadKey();
        }
    }
}
