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
        /// <summary>
        /// Adds an object to the end of the collection based on full path to the file
        /// </summary>
        /// <param name="fullPathToFile">Full path to the file</param>
        public void Add(string fullPathToFile)
        {
            Add(new File(fullPathToFile));
        }
        /// <summary>
        /// Removes the element at the specified index od collection
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the e,emet to remove</param>
        public new void RemoveAt(int rowIndex)
        {
            base.RemoveAt(rowIndex);
        }
        /// <summary>
        /// Insert an element into collection at the specified index
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted</param>
        /// <param name="fullPathToFile">Full path to the file</param>
        public void Insert(int index, string fullPathToFile)
        {
           Insert(index, new File(fullPathToFile));
        }
    }
}
