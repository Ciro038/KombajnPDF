using KombajnPDF.Data.Abstract;

namespace KombajnPDF.Data.Abstract
{
    public interface IFilePatternChecker
    {
        bool TryParse(FileItem file, out List<int> pages);
    }
}
