﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interfaces
{
    internal interface IFilesBindingList
    {
        public void Add(int rowCount,string fullPathToFile);
    }
}