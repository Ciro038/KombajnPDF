using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Interface
{
    interface IInfoFormView
    {
        event Action LoadData;
        void FillMainLicenseText(string pText);
        void FillOtherLicenseText(string pText);    
    }
}
