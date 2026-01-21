using KombajnPDF.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Abstract
{
    public interface IFilePatternChecker
    {
        bool TryParse(FileItem file, out List<int> pages);
    }
}
