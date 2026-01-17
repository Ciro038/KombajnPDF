using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Data.Abstract
{
    public interface IPdfDocument : IDisposable
    {
        int PageCount { get; }
        object GetPage(int index);
    }
}
