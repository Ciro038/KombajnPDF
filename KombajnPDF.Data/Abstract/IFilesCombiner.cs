namespace KombajnPDF.Data.Abstract
{
    public interface IFilesCombiner
    {
        void CombineFiles(List<IFileItem> items, string outputPath);
    }
}
