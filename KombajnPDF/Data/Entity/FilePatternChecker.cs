using KombajnPDF.App.Data.Abstract;
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
    internal class FilePatternChecker : IFilePatternChecker
    {
        private static readonly HashSet<char> allowedChars =
            new("0123456789-;");

        /// <summary>
        /// Method checks whether pattern contains illegal chars
        /// </summary>
        /// <param name="pattern">Pattern to check pages to print</param>
        /// <returns>true if he doesn't have it</returns>
        private bool ContainsOnlyAllowedChars(string pattern)
        {
            return pattern.All(allowedChars.Contains);
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

            if (!ContainsOnlyAllowedChars(fileItem.FilePattern))
                return false;

            if (IsAllPagesPattern(fileItem))
            {
                pages = GetAllPages(fileItem.TotalPages);
                return true;
            }

            foreach (var part in SplitPattern(fileItem))
            {
                if (!TryParsePart(part, fileItem.TotalPages, pages))
                    return false;
            }
            return true;
        }

        private bool TryParsePart(string part, int totalPages, List<int> pages)
        {
            string currentPart = part.Trim();
            if (currentPart == "-")
                return AddAllPages(totalPages, pages);

            else if (currentPart.StartsWith('-'))
                return TryParseToEnd(currentPart, totalPages, pages);

            else if (currentPart.EndsWith('-'))
                return TryParseFromStart(currentPart, totalPages, pages);

            else if (currentPart.Contains('-'))
                return TryParseRange(currentPart, totalPages, pages);

            else
                return TryParseSinglePage(currentPart, totalPages, pages);
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

        private bool AddAllPages(int totalPages, List<int> pages)
        {
            pages.AddRange(GetAllPages(totalPages));
            return true;
        }
        private IEnumerable<string> SplitPattern(FileItem fileItem)
        {
            return fileItem.FilePattern
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim());
        }

        private List<int> GetAllPages(int totalPages)
        {
            return Enumerable.Range(1, totalPages).ToList();
        }

        private bool IsAllPagesPattern(FileItem fileItem)
        {
            return string.IsNullOrEmpty(fileItem.FilePattern) || fileItem.FilePattern == "-";
        }

        private bool IsValidFileItem(FileItem fileItem)
        {
            return fileItem != null && fileItem.TotalPages > 0;
        }
    }
}
