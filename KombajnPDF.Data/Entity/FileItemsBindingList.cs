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
    public class FileItemsBindingList : BindingList<FileItem>, IFilesBindingList
    {
        /// <inheritdoc/>
        public new FileItem this[int index]
        {
            get { return base[index]; }
        }
        /// <inheritdoc/>
        public new List<FileItem> Items
        {
            get { return ((List<FileItem>)base.Items).ConvertAll(file => (FileItem)file); }
        }

        /// <inheritdoc/>
        public void Add(string fullPathToFile)
        {
            Add(new FileItem(fullPathToFile));
        }
        /// <inheritdoc/>
        public new void RemoveAt(int rowIndex)
        {
            base.RemoveAt(rowIndex);
        }
        /// <inheritdoc/>
        public void Insert(int index, string fullPathToFile)
        {
           Insert(index, new FileItem(fullPathToFile));
        }
    }
}
