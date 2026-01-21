using KombajnPDF.Data.Abstract;
using PdfSharp.Pdf.IO;
using System.ComponentModel;
using System.IO;

namespace KombajnPDF.Data.Entity;
/// <summary>
/// Class representing a file
/// </summary>
public class FileItem : IFileItem
{
    /// <inheritdoc/>
    public string FullPath { get; set; }

    /// <inheritdoc/>
    public string FileNameWithExtension { get; set; }

    /// <inheritdoc/>
    public string PathToFile { get; set; }

    [Browsable(false)]
    private string filePattern;

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public int TotalPages { get; set; }

    /// <inheritdoc/>
    public string FileExtension { get; set; }

    /// <inheritdoc/>
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
        if (!File.Exists(fullPathToFile))
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
