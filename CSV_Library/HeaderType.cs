﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Library
{
    internal enum HeaderType
    {
        FileNotExist,
        HeaderExist,
        HeaderNotExistAndDataExist,
        HeaderNotExistAndDataNotExist,
    }
}
