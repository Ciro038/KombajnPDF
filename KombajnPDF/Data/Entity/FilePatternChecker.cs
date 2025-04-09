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
    internal class FilePatternChecker
    {
        /// <summary>
        /// List of pages to print
        /// </summary>
        public List<int> ListOfPagesToPrint { get; private set; }
        /// <summary>
        /// Method checks whether the pattern is correct for the given number of pages
        /// </summary>
        /// <param name="pattern">Pattern to check pages to print</param>
        /// <param name="countOfPages">Cont of pages</param>
        /// <returns>true if patters is correct</returns>
        public bool CheckPattern(string pattern, int countOfPages)
        {
            if (string.IsNullOrEmpty(pattern) || pattern == "-")
            {
                ListOfPagesToPrint = Enumerable.Range(1, countOfPages).ToList();
                return true;
            }
            if (PatternContainsNotAllowedChars(pattern))
                return false;
            try
            {
                var pagesParts = pattern.Split(';');
                ListOfPagesToPrint = new List<int>();
                for (int i = 0; i <= pagesParts.Length - 1; i++)
                {
                    string currentPart = pagesParts[i];
                    if (currentPart == "-")
                    {
                        ListOfPagesToPrint.AddRange(Enumerable.Range(1, countOfPages));
                    }
                    else if (currentPart.StartsWith('-'))
                    {
                        int endPage = Convert.ToInt32(currentPart.Split('-')[1]);
                        if (endPage> countOfPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        ListOfPagesToPrint.AddRange(Enumerable.Range(1, endPage));
                    }
                    else if (currentPart.EndsWith('-'))
                    {
                        int startPage = Convert.ToInt32(currentPart.Split('-')[0]);
                        if (startPage > countOfPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        ListOfPagesToPrint.AddRange(Enumerable.Range(startPage, countOfPages));
                    }
                    else if (currentPart.Contains('-'))
                    {
                        var startEndPages = currentPart.Split('-');
                        int startPage= Convert.ToInt32(startEndPages[0]);
                        int endPage= Convert.ToInt32(startEndPages[1]);
                        if (startPage > countOfPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        if (endPage > countOfPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        ListOfPagesToPrint.AddRange(Enumerable.Range(startPage, endPage- startPage+1));
                    }
                    else
                    {
                        int currentPage=Convert.ToInt32(currentPart);
                        if (currentPage>countOfPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        ListOfPagesToPrint.Add(Convert.ToInt32(currentPart));
                    }
                }
            }
            catch (Exception)
            {
                ListOfPagesToPrint = null;
                return false;
            }
            return true;
        }
        /// <summary>
        /// Method checks whether pattern contains illegal chars
        /// </summary>
        /// <param name="pattern">Pattern to check pages to print</param>
        /// <returns>true if he doesn't have it</returns>
        private bool PatternContainsNotAllowedChars(string pattern)
        {
            char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', ';' };
            return pattern.Any(allowedChar => !allowedChars.Contains(allowedChar));
        }
    }
}
