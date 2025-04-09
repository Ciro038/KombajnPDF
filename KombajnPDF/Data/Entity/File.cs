using KombajnPDF.Classes;
using KombajnPDF.Data.Abstract;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KombajnPDF.Data.Entity;
/// <summary>
/// Class representing a file
/// </summary>
internal class File : IFile
{
    /// <summary>
    /// Full path to the fille
    /// </summary>
    private readonly string fullPath;

    /// <summary>
    /// File name
    /// </summary>
    [Browsable(true)]
    [DisplayName("Name")]
    public string NameDataGridViewTextBoxColumn { get; set; }

    /// <summary>
    /// Path to file
    /// </summary>
    [Browsable(true)]
    [DisplayName("Path")]
    public string PathDataGridViewTextBoxColumn { get; set; }

    /// <summary>
    /// Pattern
    /// </summary>
    [Browsable(true)]
    [DisplayName("Pattern")]
    public string PatternDataGridViewTextBoxColumn { get; set; }

    /// <summary>
    /// Count of pages
    /// </summary>
    [Browsable(true)]
    [DisplayName("Total pages")]
    public int TotalPagesDataGridViewTextBoxColumn { get; set; }

    /// <summary>
    /// Constructor creates an object based on the file path
    /// </summary>
    /// <param name="fullPathToFile">Full path to the file</param>
    /// <exception cref="ArgumentNullException">If param is nothing</exception>
    /// <exception cref="FileLoadException">if file is not a pdf</exception>
    public File(string fullPathToFile)
    {
        if (string.IsNullOrEmpty(fullPathToFile))
            throw new ArgumentNullException(nameof(fullPathToFile));
        if (!System.IO.File.Exists(fullPathToFile))
            throw new FileLoadException();
        if (!Path.GetExtension(fullPathToFile).Equals(".PDF", StringComparison.OrdinalIgnoreCase))
            throw new FileLoadException();

        fullPath = fullPathToFile;
        NameDataGridViewTextBoxColumn = Path.GetFileName(fullPathToFile);
        PathDataGridViewTextBoxColumn = Path.GetDirectoryName(fullPathToFile);
        PatternDataGridViewTextBoxColumn = "-";
        TotalPagesDataGridViewTextBoxColumn = PdfReader.Open(fullPathToFile, PdfDocumentOpenMode.Import).PageCount;
    }
    /// <summary>
    /// Method checks pattern
    /// </summary>
    /// <returns>true if pattern is correct</returns>
    public bool CheckPattern()
    {
        var fileChecker = new FilePatternChecker();
        return fileChecker.CheckPattern(PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn);
    }
    /// <summary>
    /// Method gets a list of pages to print
    /// </summary>
    /// <returns></returns>
    public List<int> GetPagesToPrint()
    {
        var fileChecker = new FilePatternChecker();
        fileChecker.CheckPattern(PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn);
        return fileChecker.ListOfPagesToPrint;
    }
    /// <summary>
    /// Get full path to the file
    /// </summary>
    /// <returns>full path</returns>
    public string GetFullPath()
    {
        return fullPath;
    }
}
