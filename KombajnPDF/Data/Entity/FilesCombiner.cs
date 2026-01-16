using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace KombajnPDF.Data.Entity
{
    /// <summary>
    /// Class responsible for combining files into a single PDF
    /// </summary>
    public class FilesCombiner
    {
        public static readonly HashSet<string> AllowedFileExtensions =
            new(new[] { ".jpg", ".jpeg", ".png", ".pdf" },
                StringComparer.OrdinalIgnoreCase);
        private MemoryStream CreatePdfStreamFromImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                throw new ArgumentException("Image path must not be null or empty.", nameof(imagePath));

            var ms = new MemoryStream();

            using var tempDoc = new PdfDocument();

            using var image = XImage.FromFile(imagePath);

            double width = image.PixelWidth * 72.0 / image.HorizontalResolution;
            double height = image.PixelHeight * 72.0 / image.VerticalResolution;

            var page = tempDoc.AddPage();
            page.Width = width;
            page.Height = height;

            using var gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(image, 0, 0, width, height);

            tempDoc.Save(ms, false);
            ms.Position = 0;
            return ms;
        }
        private void ImportPages(PdfDocument target, PdfDocument source, List<int> pages, string sourceName)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pages == null) throw new ArgumentNullException(nameof(pages));

            for (int i = 0; i < pages.Count; i++)
            {
                int pageNumber = pages[i];
                if (pageNumber < 1 || pageNumber > source.PageCount)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(pages),
                        $"Requested page {pageNumber} from \"{sourceName}\" is outside the available range (1..{source.PageCount}).");
                }

                target.AddPage(source.Pages[pageNumber - 1]);
            }
        }

        /// <summary>
        /// Combine files into a single PDF file at the given path 
        /// </summary>
        /// <param name="items">Files to combine</param>
        /// <param name="fullPathTofile">Full path to generated combined final file</param>
        /// <exception cref="ArgumentException">Thrown when destination path is null/empty.</exception>
        /// <exception cref="FormatException">Thrown when a file's page pattern is invalid.</exception>
        public void CombineFiles(List<FileItem> items, string fullPathTofile)
        {
            if (string.IsNullOrEmpty(fullPathTofile))
                throw new ArgumentException("First choose where to save the file.", nameof(fullPathTofile));

            if (items == null || items.Count == 0)
                return;

            var patternChecker = new FilePatternChecker();

            using var mainDocument = new PdfDocument();

            foreach (var file in items)
            {

                if (!patternChecker.TryParse(file, out var pages))
                    throw new FormatException($"Wrong pattern for file: {file.FileNameWithExtension}");

                if (file.IsPDF)
                {
                    using var sourceDocument = PdfReader.Open(file.FullPath, PdfDocumentOpenMode.Import);
                    ImportPages(mainDocument, sourceDocument, pages, file.FileNameWithExtension);
                }
                else
                {
                    using var ms = CreatePdfStreamFromImage(file.FullPath);
                    ms.Position = 0;
                    using var importDoc = PdfReader.Open(ms, PdfDocumentOpenMode.Import);
                    ImportPages(mainDocument, importDoc, pages, file.FileNameWithExtension);
                }
            }
            mainDocument.Save(fullPathTofile);
        }
    }
}