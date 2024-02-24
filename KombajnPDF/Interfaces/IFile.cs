using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interfaces
{
    internal interface IFile
    {
        public string NameDataGridViewTextBoxColumn { get; set; }
        public string PathDataGridViewTextBoxColumn { get; set; }
        public string PatternDataGridViewTextBoxColumn { get; set; }
        public int TotalPagesDataGridViewTextBoxColumn { get; set; }
        public string GetFullPath();
        public bool CheckPattern();
        public List<int> GetPagesToPrint();
    }
}
