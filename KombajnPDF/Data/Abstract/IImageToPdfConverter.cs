using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Data.Abstract
{
    public interface IImageToPdfConverter
    {
        MemoryStream Convert(string imagePath);
    }
}
