using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    internal class FilePatternChecker
    {
        private List<int> listOfPagesToPrint;
        public List<int> ListOfPagesToPrint
        {
            get { return listOfPagesToPrint; }
        }
        public bool CheckPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return false;
            if (PatternContainsNotAllowedChars(pattern))
                return false;

            return false;
        }
        private bool PatternContainsNotAllowedChars(string pattern)
        {
            char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', ';' };
            return pattern.Any(allowedChar => !allowedChars.Contains(allowedChar));
        }
    }
}
