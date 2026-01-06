using KombajnPDF.Classes;
using KombajnPDF.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Abstract
{
    internal interface IFilesBindingList
    {
        List<FileItem> Items { get; }
        public FileItem this[int index] { get; }
        /// <summary>
        /// Adds an object to the end of the collection based on full path to the file
        /// </summary>
        /// <param name="fullPathToFile">Full path to the file</param>
        public void Add(string fullPathToFile);
        /// <summary>
        /// Removes the element at the specified index od collection
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the e,emet to remove</param>
        public void RemoveAt(int rowIndex);
        /// <summary>
        /// Insert an element into collection at the specified index
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted</param>
        /// <param name="fullPathToFile">Full path to the file</param>
        public void Insert(int index, string fullPathToFile);

    }
}
