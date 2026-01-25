using KombajnPDF.Data.Abstract;

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
        private readonly IPdfLoader _pdfLoader;

        public FilesCombiner(
            IFilePatternChecker patternChecker,
            IPdfLoader pdfLoader)
        {
            _patternChecker = patternChecker;
            _pdfLoader = pdfLoader;
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

        public void CombineFiles(List<IFileItem> items, string outputPath)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
                throw new ArgumentException(nameof(outputPath));

            if (items == null || items.Count == 0)
                return;

            using IPdfDocument result = _pdfLoader.CreateEmpty();

            foreach (IFileItem file in items)
            {
                if (!_patternChecker.TryParse(file, out var pages))
                    throw new FormatException($"Invalid pattern for the file: {file.FileNameWithExtension}");

                using IPdfDocument source = _pdfLoader.Load(file);

                ImportPages(result, source, pages);
            }

            _pdfLoader.Save(result, outputPath);
        }
    }
}