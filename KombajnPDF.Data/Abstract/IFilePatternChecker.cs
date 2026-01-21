using KombajnPDF.Data.Entity;

namespace KombajnPDF.Data.Abstract
{
    public interface IFilePatternChecker
    {
        bool TryParse(FileItem file, out List<int> pages);
    }
}
