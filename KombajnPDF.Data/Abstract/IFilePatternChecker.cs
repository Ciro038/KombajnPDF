using KombajnPDF.Data.Entity;

namespace KombajnPDF.Data.Abstract
{
    public interface IFilePatternChecker
    {
        bool TryParse(IFileItem file, out List<int> pages);
    }
}
