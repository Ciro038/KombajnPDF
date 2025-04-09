using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Abstract
{
    internal interface IFile
    {
        /// <summary>
        /// File name
        /// </summary>
        public string NameDataGridViewTextBoxColumn { get; set; }
        /// <summary>
        /// Path to file
        /// </summary>
        public string PathDataGridViewTextBoxColumn { get; set; }
        /// <summary>
        /// Pattern
        /// </summary>
        public string PatternDataGridViewTextBoxColumn { get; set; }
        /// <summary>
        /// Count of pages
        /// </summary>
        public int TotalPagesDataGridViewTextBoxColumn { get; set; }
        /// <summary>
        /// Get full path to the file
        /// </summary>
        /// <returns>full path</returns>
        public string GetFullPath();
        /// <summary>
        /// Method checks pattern
        /// </summary>
        /// <returns>true if pattern is correct</returns>
        public bool CheckPattern();
        /// <summary>
        /// Method gets a list of pages to print
        /// </summary>
        /// <returns></returns>
        public List<int> GetPagesToPrint();
    }
}
