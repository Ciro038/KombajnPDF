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

    internal class File
    {
        [Browsable(false)]
        public string FullPath { get; private set; }

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
            FullPath = fullPathToFile;
            NameDataGridViewTextBoxColumn = Path.GetFileName(fullPathToFile);
            PathDataGridViewTextBoxColumn = Path.GetDirectoryName(fullPathToFile);
            PatternDataGridViewTextBoxColumn = "-";
            TotalPagesDataGridViewTextBoxColumn = PdfReader.Open(fullPathToFile, PdfDocumentOpenMode.Import).PageCount;
        }

        internal bool CheckPattern()
        {
            var fileChecker = new FilePatternChecker();
            return fileChecker.CheckPattern(PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn);
        }
        internal List<int> GetPagesToPrint()
        {
            var fileChecker = new FilePatternChecker();
            fileChecker.CheckPattern(PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn);
            return fileChecker.ListOfPagesToPrint;
        }
    }
}
