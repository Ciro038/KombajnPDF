using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KombajnPDF.Classes;

namespace KombajnPDF.Interfaces
{
    internal interface IFilesBindingList
    {
        List<Classes.File> Items { get; }
        public Classes.File this[int index] { get; }
        public void Add(string fullPathToFile);
        public void RemoveAt(int rowIndex);
        public void Insert(int index, Classes.File file);

    }
}
