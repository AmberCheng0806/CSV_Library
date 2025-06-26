using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library
{
    internal class DataDTO
    {
        public string Detail { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public DataDTO(string detail, string name, string context)
        {
            Detail = detail;
            Name = name;
            Context = context;
        }

        public DataDTO() { }
    }
}
