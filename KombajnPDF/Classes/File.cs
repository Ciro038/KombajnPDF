using KombajnPDF.Interfaces;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KombajnPDF.Classes
{
    internal class File : IFile
    {
        private readonly string fullPath;

        [Browsable(true)]
        [DisplayName("Name")]
        public string NameDataGridViewTextBoxColumn { get; set; }

        [Browsable(true)]
        [DisplayName("Path")]
        public string PathDataGridViewTextBoxColumn { get; set; }

        [Browsable(true)]
        [DisplayName("Pattern")]
        public string PatternDataGridViewTextBoxColumn { get; set; }

        [Browsable(true)]
        [DisplayName("Total pages")]
        public int TotalPagesDataGridViewTextBoxColumn { get; set; }

        public File(string fullPathToFile)
        {
            if (fullPathToFile == null)
                throw new ArgumentNullException(nameof(fullPathToFile));
            if (String.IsNullOrEmpty(fullPathToFile))
            {
                throw new ArgumentNullException(nameof(fullPathToFile));
            }
            if (!System.IO.File.Exists(fullPathToFile))
                throw new FileLoadException();
            if (!Path.GetExtension(fullPathToFile).Equals(".PDF", StringComparison.CurrentCultureIgnoreCase))
                return;
            fullPath = fullPathToFile;
            NameDataGridViewTextBoxColumn = Path.GetFileName(fullPathToFile);
            PathDataGridViewTextBoxColumn = Path.GetDirectoryName(fullPathToFile);
            PatternDataGridViewTextBoxColumn = "-";
            TotalPagesDataGridViewTextBoxColumn = PdfReader.Open(fullPathToFile, PdfDocumentOpenMode.Import).PageCount;
        }

        public bool CheckPattern()
        {
            var fileChecker = new FilePatternChecker();
            return fileChecker.CheckPattern(PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn);
        }
        public List<int> GetPagesToPrint()
        {
            var fileChecker = new FilePatternChecker();
            fileChecker.CheckPattern(PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn);
            return fileChecker.ListOfPagesToPrint;
        }
        public string GetFullPath()
        {
            return fullPath;
        }
    }
}
