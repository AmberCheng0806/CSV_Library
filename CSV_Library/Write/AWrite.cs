using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library.Write
{
    abstract class AWrite<T>
    {
        public abstract void Write(string path, List<T> models, string header);
    }
}
