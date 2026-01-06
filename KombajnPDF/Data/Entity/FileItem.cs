using KombajnPDF.Data.Abstract;
using PdfSharp.Pdf.IO;
using System.ComponentModel;

namespace KombajnPDF.Data.Entity;
/// <summary>
/// Class representing a file
/// </summary>
internal class FileItem
{
    /// <summary>
    /// Full path to the fille
    /// </summary>
    [Browsable(false)]
    public string FullPath;

    /// <summary>
    /// FileItem name
    /// </summary>
    [Browsable(true)]
    public string FileNameWithExtension { get; set; }

    /// <summary>
    /// Path to file
    /// </summary>
    [Browsable(true)]
    public string PathToFile { get; set; }

    /// <summary>
    /// Pattern
    /// </summary>
    [Browsable(true)]
    public string FileItemPattern { get; set; }

    /// <summary>
    /// Count of pages
    /// </summary>
    [Browsable(true)]
    public int TotalPages { get; set; }

    /// <summary>
    /// Constructor creates an object based on the file path
    /// </summary>
    /// <param name="fullPathToFile">Full path to the file</param>
    /// <exception cref="ArgumentNullException">If param is nothing</exception>
    /// <exception cref="FileLoadException">if file is not a pdf</exception>
    public FileItem(string fullPathToFile)
    {
        if (string.IsNullOrEmpty(fullPathToFile))
            throw new ArgumentNullException(nameof(fullPathToFile));
        if (!System.IO.File.Exists(fullPathToFile))
            throw new FileLoadException();
        if (!Path.GetExtension(fullPathToFile).Equals(".PDF", StringComparison.OrdinalIgnoreCase))
            throw new FileLoadException();

        FullPath = fullPathToFile;
        FileNameWithExtension = Path.GetFileName(fullPathToFile);
        PathToFile = Path.GetDirectoryName(fullPathToFile);
        FileItemPattern = "-";
        TotalPages = PdfReader.Open(fullPathToFile, PdfDocumentOpenMode.Import).PageCount;
    }
    /// <summary>
    /// Method checks pattern
    /// </summary>
    /// <returns>true if pattern is correct</returns>
    public bool CheckPattern()
    {
        var fileChecker = new FilePatternChecker();
        return fileChecker.CheckPattern(FileItemPattern, TotalPages);
    }
    /// <summary>
    /// Method gets a list of pages to print
    /// </summary>
    /// <returns></returns>
    public List<int> GetPagesToPrint()
    {
        var fileChecker = new FilePatternChecker();
        fileChecker.CheckPattern(FileItemPattern, TotalPages);
        return fileChecker.ListOfPagesToPrint;
    }
}
