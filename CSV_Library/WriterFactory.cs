using CSV_Library.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library
{
    internal class WriterFactory
    {
        public static AWrite<T> CreateWrite<T>(HeaderType type)
        {
            switch (type)
            {
                case HeaderType.FileNotExist:
                    return new FileNotExist<T>();
                case HeaderType.HeaderExist:
                    return new HeaderExist<T>();
                case HeaderType.HeaderNotExistAndDataExist:
                    return new HeaderNotExistAndDataExist<T>();
                case HeaderType.HeaderNotExistAndDataNotExist:
                    return new HeaderNotExistAndDataNotExist<T>();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
