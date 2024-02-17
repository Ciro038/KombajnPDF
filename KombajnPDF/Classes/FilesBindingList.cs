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
    internal class FilesBindingList : BindingList<File>
    {
        public void Add(int rowIndex, string fullPathToFile)
        {
            if (fullPathToFile == null)
                throw new ArgumentNullException(nameof(fullPathToFile));
            if (!System.IO.File.Exists(fullPathToFile))
                throw new FileLoadException();
            if (Path.GetExtension(fullPathToFile).ToUpper() != ".PDF")
                return;
            base.Add(new File(rowIndex, fullPathToFile));
        }
    }
}
