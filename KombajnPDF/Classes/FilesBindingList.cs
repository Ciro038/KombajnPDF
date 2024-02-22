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
        public new File this[int index]
        {
            get { return base[index]; }
        }
        public new List<File> Items
        {
            get { return (List<File>)base.Items; }
        }
        public void Add(string fullPathToFile)
        {
            if (fullPathToFile == null)
                throw new ArgumentNullException(nameof(fullPathToFile));
            if (String.IsNullOrEmpty(fullPathToFile))
            {
                throw new ArgumentNullException(nameof(fullPathToFile));
            }
            if (!System.IO.File.Exists(fullPathToFile))
                throw new FileLoadException();
            if (!Path.GetExtension(fullPathToFile).Equals(".PDF", StringComparison.CurrentCultureIgnoreCase))
                return;
            base.Add(new File(fullPathToFile));
        }

        public new void RemoveAt(int rowIndex)
        {
            base.RemoveAt(rowIndex);
        }
        public new void Insert(int index, File file)
        {
            base.Insert(index, file);
        }
    }
}
