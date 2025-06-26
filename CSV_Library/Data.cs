using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library
{
    internal class Data
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public string Type { get; set; }

        public string Detail { get; set; }

        public string Context { get; set; }

        public Data(string name, string value, string type, string detail, string context)
        {
            Name = name; Value = value; Type = type;
            Detail = detail;
            Context = context;
        }
        public Data() { }
    }
}
