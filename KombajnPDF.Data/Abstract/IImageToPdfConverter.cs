using System.IO;

namespace KombajnPDF.Data.Abstract
{
    public interface IImageToPdfConverter
    {
        MemoryStream Convert(string imagePath);
    }
}
