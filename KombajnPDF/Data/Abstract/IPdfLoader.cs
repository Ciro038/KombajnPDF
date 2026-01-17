using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Data.Abstract
{
    public interface IPdfLoader
    {
        IPdfDocument Load(string path);
        IPdfDocument Load(Stream stream);
        IPdfDocument CreateEmpty();
        void AddPage(IPdfDocument target, object page);
        void Save(IPdfDocument document, string path);
    }
}
