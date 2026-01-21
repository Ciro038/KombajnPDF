using KombajnPDF.Data.Abstract;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;

namespace KombajnPDF.Data.Entity
{
    public class PdfSharpLoader : IPdfLoader
    {
        public IPdfDocument CreateEmpty()
            => new PdfSharpDocumentWrapper(new PdfDocument());

        public IPdfDocument Load(string path)
            => new PdfSharpDocumentWrapper(
                PdfReader.Open(path, PdfDocumentOpenMode.Import));

        public IPdfDocument Load(Stream stream)
            => new PdfSharpDocumentWrapper(
                PdfReader.Open(stream, PdfDocumentOpenMode.Import));

        public void AddPage(IPdfDocument target, object page)
        {
            ((PdfSharpDocumentWrapper)target).Document.AddPage((PdfPage)page);
        }

        public void Save(IPdfDocument document, string path)
        {
            ((PdfSharpDocumentWrapper)document).Document.Save(path);
        }
    }
}
