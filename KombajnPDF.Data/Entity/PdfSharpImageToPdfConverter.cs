using KombajnPDF.Data.Abstract;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;

namespace KombajnPDF.Data.Abstract
{
    public class PdfSharpImageToPdfConverter : IImageToPdfConverter
    {
        public MemoryStream Convert(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new ArgumentException(nameof(imagePath));

            var stream = new MemoryStream();

            using var document = new PdfDocument();
            using var image = XImage.FromFile(imagePath);

            double width = image.PixelWidth * 72.0 / image.HorizontalResolution;
            double height = image.PixelHeight * 72.0 / image.VerticalResolution;

            var page = document.AddPage();
            page.Width = width;
            page.Height = height;

            using var gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(image, 0, 0, width, height);

            document.Save(stream, false);
            stream.Position = 0;

            return stream;
        }
    }
}
