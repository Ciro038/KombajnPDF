using KombajnPDF.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    internal class FilesBindingList : BindingList<File>, IFilesBindingList
    {
        public new IFile this[int index]
        {
            get { return base[index]; }
        }
        public new List<IFile> Items
        {
            get { return ((List<File>)base.Items).ConvertAll(file => (IFile)file); }
        }
        public void Add(string fullPathToFile)
        {
            base.Add(new File(fullPathToFile));
        }

        public new void RemoveAt(int rowIndex)
        {
            base.RemoveAt(rowIndex);
        }
        public void Insert(int index, string fullPathToFile)
        {
            base.Insert(index, new File(fullPathToFile));
        }
    }
}
