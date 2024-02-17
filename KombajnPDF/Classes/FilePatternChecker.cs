using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    internal class FilePatternChecker
    {
        public List<int> ListOfPagesToPrint { get; private set; }
        public bool CheckPattern(string pattern, int totalPages)
        {
            if (String.IsNullOrEmpty(pattern) || pattern == "-")
            {
                ListOfPagesToPrint = Enumerable.Range(1, totalPages).ToList();
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
                        ListOfPagesToPrint.AddRange(Enumerable.Range(1, totalPages));
                    }
                    else if (currentPart.StartsWith("-"))
                    {
                        int endPage = Convert.ToInt32(currentPart.Split("-")[1]);
                        if (endPage> totalPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        ListOfPagesToPrint.AddRange(Enumerable.Range(1, endPage));
                    }
                    else if (currentPart.EndsWith("-"))
                    {
                        int startPage = Convert.ToInt32(currentPart.Split("-")[0]);
                        if (startPage > totalPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        ListOfPagesToPrint.AddRange(Enumerable.Range(startPage, totalPages));
                    }
                    else if (currentPart.Contains("-"))
                    {
                        var startEndPages = currentPart.Split("-");
                        int startPage= Convert.ToInt32(startEndPages[0]);
                        int endPage= Convert.ToInt32(startEndPages[1]);
                        if (startPage > totalPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        if (endPage > totalPages)
                        {
                            throw new InvalidDataException("Invbalid page number");
                        }
                        ListOfPagesToPrint.AddRange(Enumerable.Range(startPage, endPage));
                    }
                    else
                    {
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
        private bool PatternContainsNotAllowedChars(string pattern)
        {
            char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', ';' };
            return pattern.Any(allowedChar => !allowedChars.Contains(allowedChar));
        }
    }
}
