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
        List<IFile> Items { get; }
        public IFile this[int index] { get; }
        public void Add(string fullPathToFile);
        public void RemoveAt(int rowIndex);
        public void Insert(int index, string fullPathToFile);

    }
}
