using System.IO;

namespace KombajnPDF.Data.Abstract
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
