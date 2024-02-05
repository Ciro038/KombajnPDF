using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{

    internal class File
    {
        private static int newId = 1;
        private string fullPath { get; set; }

        [Browsable(false)]
        public int Id { get; set; }

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

        public File(string fullPath)
        {
            Id = newId++;
            this.fullPath = fullPath;
            NameDataGridViewTextBoxColumn = Path.GetFileName(fullPath);
            PathDataGridViewTextBoxColumn = Path.GetDirectoryName(fullPath);
            PatternDataGridViewTextBoxColumn = "-";
            TotalPagesDataGridViewTextBoxColumn = PdfReader.Open(fullPath,PdfDocumentOpenMode.Import).PageCount;
        }
    }
}
