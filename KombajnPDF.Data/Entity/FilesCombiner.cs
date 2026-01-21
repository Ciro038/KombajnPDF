using KombajnPDF.Data.Abstract;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace KombajnPDF.Data.Entity
{
    /// <summary>
    /// Class responsible for combining files into a single PDF
    /// </summary>
    public class FilesCombiner : IFilesCombiner
    {
        public static readonly HashSet<string> AllowedFileExtensions =
            new(new[] { ".jpg", ".jpeg", ".png", ".pdf" },
                StringComparer.OrdinalIgnoreCase);

        private readonly IFilePatternChecker _patternChecker;
        private readonly IImageToPdfConverter _imageConverter;
        private readonly IPdfLoader _pdfLoader;

        public FilesCombiner(
            IFilePatternChecker patternChecker,
            IImageToPdfConverter imageConverter,
            IPdfLoader pdfLoader)
        {
            _patternChecker = patternChecker;
            _imageConverter = imageConverter;
            _pdfLoader = pdfLoader;
        }

        public void CombineFiles(List<FileItem> items, string outputPath)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
                throw new ArgumentException(nameof(outputPath));

            if (items == null || items.Count == 0)
                return;

            using var result = _pdfLoader.CreateEmpty();

            foreach (var file in items)
            {
                if (!_patternChecker.TryParse(file, out var pages))
                    throw new FormatException($"Invalid pattern for file: {file.FileNameWithExtension}");

                using var source = file.IsPDF
                    ? _pdfLoader.Load(file.FullPath)
                    : LoadImageAsPdf(file.FullPath);

                ImportPages(result, source, pages);
            }

            _pdfLoader.Save(result, outputPath);
        }

        private IPdfDocument LoadImageAsPdf(string path)
        {
            var stream = _imageConverter.Convert(path);
            return _pdfLoader.Load(stream);
        }

        private void ImportPages(
            IPdfDocument target,
            IPdfDocument source,
            List<int> pages)
        {
            foreach (var pageNumber in pages)
            {
                if (pageNumber < 1 || pageNumber > source.PageCount)
                    throw new ArgumentOutOfRangeException(nameof(pages));

                var page = source.GetPage(pageNumber - 1);
                _pdfLoader.AddPage(target, page);
            }
        }
    }
}