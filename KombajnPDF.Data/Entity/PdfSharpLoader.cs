using KombajnPDF.Data.Abstract;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Drawing;
using System.IO;

namespace KombajnPDF.Data.Entity
{
    public class PdfSharpLoader : IPdfLoader
    {
        public readonly IImageToPdfConverter _imageConverter;
        public PdfSharpLoader(IImageToPdfConverter imageToPdfConverter)
        {
            _imageConverter = imageToPdfConverter;
        }

        private IPdfDocument Load(string path)
            => new PdfSharpDocumentWrapper(
                PdfReader.Open(path, PdfDocumentOpenMode.Import));

        private IPdfDocument Load(Stream stream)
            => new PdfSharpDocumentWrapper(
                PdfReader.Open(stream, PdfDocumentOpenMode.Import));

        private IPdfDocument LoadImageAsPdf(string path)
        {
            var stream = _imageConverter.Convert(path);
            return Load(stream);
        }

        public IPdfDocument CreateEmpty()
            => new PdfSharpDocumentWrapper(new PdfDocument());

        public IPdfDocument Load(IFileItem fileItem)
        {
            if (fileItem.IsPDF)
                return Load(fileItem.FullPath);
            else
                return LoadImageAsPdf(fileItem.FullPath);
        }
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
