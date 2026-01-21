using KombajnPDF.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Abstract
{
    public interface IFilesCombiner
    {
        void CombineFiles(List<FileItem> items, string fullPathToFile);
    }
}
