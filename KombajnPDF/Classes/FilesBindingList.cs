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
        public void Add(string fullPathToFile)
        {
            base.Add(new File(fullPathToFile)) ;
        }
    }
}
