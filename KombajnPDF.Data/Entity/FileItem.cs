using PdfSharp.Pdf.IO;
using System.ComponentModel;
using System.IO;

namespace KombajnPDF.Data.Entity;
/// <summary>
/// Class representing a file
/// </summary>
public class FileItem
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

    [Browsable(false)]
    private string filePattern;
    /// <summary>
    /// Pattern
    /// </summary>
    [Browsable(true)]
    public string FilePattern
    {
        get
        {
            if (string.IsNullOrEmpty(filePattern))
                return "-";
            return filePattern;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                filePattern = "-";
            else
                filePattern = value.Trim();
        }
    }

    /// <summary>
    /// Count of pages
    /// </summary>
    [Browsable(true)]
    public int TotalPages { get; set; }

    /// <summary>
    /// Extension of the file
    /// </summary>
    [Browsable(false)]
    public string FileExtension { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the document is in PDF format
    /// </summary>
    [Browsable(false)]
    public bool IsPDF { get; set; }

    /// <summary>
    /// Constructor creates an object based on the file path
    /// </summary>
    /// <param name="fullPathToFile">Full path to the file</param>
    /// <exception cref="ArgumentNullException">If param is nothing</exception>
    /// <exception cref="FileLoadException">if file has not allowed extension</exception>
    /// <exception cref="FileNotFoundException">if file do not exists</exception>
    public FileItem(string fullPathToFile)
    {
        if (string.IsNullOrEmpty(fullPathToFile))
            throw new ArgumentNullException(nameof(fullPathToFile));
        if (!System.IO.File.Exists(fullPathToFile))
            throw new FileNotFoundException();

        FileExtension = Path.GetExtension(fullPathToFile).ToLower();

        // check if file has allowed extension 
        if (!FilesCombiner.AllowedFileExtensions.Contains(FileExtension))
            throw new FileLoadException();

        FullPath = fullPathToFile;
        FileNameWithExtension = Path.GetFileName(fullPathToFile);
        PathToFile = Path.GetDirectoryName(fullPathToFile);

        IsPDF = string.Equals(
            FileExtension,
            ".pdf",
            StringComparison.OrdinalIgnoreCase);

        if (IsPDF)
        {
            TotalPages = PdfReader.Open(fullPathToFile, PdfDocumentOpenMode.Import).PageCount;
        }
        else
        {
            TotalPages = 1;
        }
    }
}
