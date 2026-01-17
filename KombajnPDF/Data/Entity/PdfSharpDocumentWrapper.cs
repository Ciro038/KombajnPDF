using KombajnPDF.App.Data.Abstract;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Data.Entity
{
    public class PdfSharpDocumentWrapper : IPdfDocument
    {
        public PdfDocument Document { get; }

        public PdfSharpDocumentWrapper(PdfDocument document)
        {
            Document = document;
        }

        public int PageCount => Document.PageCount;

        public object GetPage(int index) => Document.Pages[index];

        public void Dispose() => Document.Dispose();
    }
}
