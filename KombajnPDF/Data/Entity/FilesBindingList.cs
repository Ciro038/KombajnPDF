using KombajnPDF.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Entity
{
    internal class FilesBindingList : BindingList<IFile>, IFilesBindingList
    {
        /// <inheritdoc/>
        public new IFile this[int index]
        {
            get { return base[index]; }
        }
        /// <inheritdoc/>
        public new List<IFile> Items
        {
            get { return ((List<File>)base.Items).ConvertAll(file => (IFile)file); }
        }
        /// <inheritdoc/>
        public void Add(string fullPathToFile)
        {
            Add(new File(fullPathToFile));
        }
        /// <inheritdoc/>
        public new void RemoveAt(int rowIndex)
        {
            base.RemoveAt(rowIndex);
        }
        /// <inheritdoc/>
        public void Insert(int index, string fullPathToFile)
        {
           Insert(index, new File(fullPathToFile));
        }
    }
}
