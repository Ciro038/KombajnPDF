using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Abstract
{
    public interface IFileItemFactory
    {
        IFileItem Create(string path);
    }
}
