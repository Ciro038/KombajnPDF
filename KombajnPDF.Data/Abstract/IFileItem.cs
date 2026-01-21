namespace KombajnPDF.Data.Abstract
{
    public interface IFileItem
    {
        string FullPath { get; set; }
        string FileExtension { get; set; }
        string FileNameWithExtension { get; set; }
        string FilePattern { get; set; }
        bool IsPDF { get; set; }
        string PathToFile { get; set; }
        int TotalPages { get; set; }
    }
}