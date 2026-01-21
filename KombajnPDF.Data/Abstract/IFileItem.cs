using System.ComponentModel;

namespace KombajnPDF.Data.Abstract
{
    public interface IFileItem
    {
        /// <summary>
        /// Full path to the fille
        /// </summary>
        [Browsable(false)]
        string FullPath { get; set; }
        /// <summary>
        /// Extension of the file
        /// </summary>
        [Browsable(false)]
        string FileExtension { get; set; }
        /// <summary>
        /// FileItem name
        /// </summary>
        [Browsable(true)]
        string FileNameWithExtension { get; set; }
        /// <summary>
        /// Pattern
        /// </summary>
        [Browsable(true)]
        string FilePattern { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the document is in PDF format
        /// </summary>
        [Browsable(false)]
        bool IsPDF { get; set; }
        /// <summary>
        /// Path to file
        /// </summary>
        [Browsable(true)]
        string PathToFile { get; set; }
        /// <summary>
        /// Count of pages
        /// </summary>
        [Browsable(true)]
        int TotalPages { get; set; }
    }
}