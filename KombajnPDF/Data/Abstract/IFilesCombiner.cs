using KombajnPDF.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Data.Abstract
{
    public interface IFilesCombiner
    {
        void CombineFiles(List<FileItem> items, string fullPathToFile);
    }
}
