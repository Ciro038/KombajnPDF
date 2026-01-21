using KombajnPDF.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Entity
{
    public class FileItemFactory : IFileItemFactory
    {
        public IFileItem Create(string path) => new FileItem(path);
    }
}
