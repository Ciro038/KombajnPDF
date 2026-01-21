using KombajnPDF.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Entity
{
    /// <summary>
    /// Class to validate pattern for the file
    /// </summary>
    public class FilePatternChecker : IFilePatternChecker
    {
        private static readonly HashSet<char> allowedChars =
            new("0123456789-;");

        /// <summary>
        /// Method checks whether pattern contains illegal chars
        /// </summary>
        /// <param name="pattern">Pattern to check pages to print</param>
        /// <returns>true if he doesn't have it</returns>
        private bool ContainsOnlyAllowedChars(FileItem fileItem)
        {
            return fileItem.FilePattern.All(allowedChars.Contains);
        }

        /// <summary>
        /// Method checks whether the FileItem has correct pattern and parses it
        /// </summary>
        /// <param name="fileItem">FileItem to check</param>
        /// <param name="pages">List of pages to print</param>
        /// <returns>true if FileItem is correct</returns>
        public bool TryParse(FileItem fileItem, out List<int> pages)
        {
            pages = new List<int>();

            if (!IsValidFileItem(fileItem))
                return false;

            if (!ContainsOnlyAllowedChars(fileItem))
                return false;

            if (IsOnePagePattern(fileItem))
            {
                if (!TryParseOnePage(fileItem))
                    return false;

                pages = GetFirstPage(fileItem);
                return true;
            }

            if (IsAllPagesPattern(fileItem))
            {
                pages = GetAllPages(fileItem);
                return true;
            }

            foreach (var part in SplitPattern(fileItem))
            {
                if (!TryParsePart(part, fileItem, pages))
                    return false;
            }
            return true;
        }

        private bool TryParseOnePage(FileItem fileItem)
        {
            return int.TryParse(fileItem.FilePattern, out int page) &&
                   page <= fileItem.TotalPages;
        }

        private bool TryParsePart(string part, FileItem fileItem, List<int> pages)
        {
            string currentPart = part.Trim();
            if (currentPart == "-")
                return AddAllPages(fileItem, pages);

            else if (currentPart.StartsWith('-'))
                return TryParseToEnd(currentPart, fileItem.TotalPages, pages);

            else if (currentPart.EndsWith('-'))
                return TryParseFromStart(currentPart, fileItem.TotalPages, pages);

            else if (currentPart.Contains('-'))
                return TryParseRange(currentPart, fileItem.TotalPages, pages);

            else
                return TryParseSinglePage(currentPart, fileItem.TotalPages, pages);
        }

        private bool TryParseSinglePage(string part, int totalPages, List<int> pages)
        {
            if (!int.TryParse(part, out int page) ||
                 page > totalPages)
            {
                return false;
            }
            else
            {
                pages.Add(page);
                return true;
            }
        }

        private bool TryParseRange(string part, int totalPages, List<int> pages)
        {
            var parts = part.Split('-');
            if (parts.Length != 2 ||
                    !int.TryParse(parts[0], out int startPage) ||
                    !int.TryParse(parts[1], out int endPage) ||
                    startPage > totalPages ||
                    endPage > totalPages)
            {
                return false;
            }
            else
            {
                pages.AddRange(Enumerable.Range(startPage, endPage - startPage + 1));
                return true;
            }
        }

        private bool TryParseFromStart(string part, int totalPages, List<int> pages)
        {
            if (!int.TryParse(part[..^1], out int startPage) ||
                startPage > totalPages)
            {
                return false;
            }
            else
            {
                pages.AddRange(Enumerable.Range(startPage, totalPages));
                return true;
            }
        }

        private bool TryParseToEnd(string part, int totalPages, List<int> pages)
        {
            if (!int.TryParse(part[1..], out int endPage) ||
                endPage > totalPages)
            {
                return false;
            }
            else
            {
                pages.AddRange(Enumerable.Range(1, endPage));
                return true;
            }
        }

        private bool AddAllPages(FileItem fileItem, List<int> pages)
        {
            pages.AddRange(GetAllPages(fileItem));
            return true;
        }
        private IEnumerable<string> SplitPattern(FileItem fileItem)
        {
            return fileItem.FilePattern
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim());
        }

        private List<int> GetAllPages(FileItem fileItem)
        {
            return Enumerable.Range(1, fileItem.TotalPages).ToList();
        }
        private List<int> GetFirstPage(FileItem fileItem)
        {
            return new List<int> { 1 };
        }
        private bool IsOnePagePattern(FileItem fileItem)
        {
            return int.TryParse(fileItem.FilePattern, out var value);
        }

        private bool IsAllPagesPattern(FileItem fileItem)
        {
            if (string.IsNullOrEmpty(fileItem.FilePattern))
                return true;
            if (string.Equals(fileItem.FilePattern, "-", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        private bool IsValidFileItem(FileItem fileItem)
        {
            return fileItem != null && fileItem.TotalPages > 0;
        }
    }
}
