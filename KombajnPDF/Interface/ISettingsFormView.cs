using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interface
{
    interface ISettingsFormView
    {
        event Action LoadAvailableLanguages;
        event Action<LanguagesEnum> LanguageChanged;
        void SetAvailableLanguages(LanguagesEnum currentLanguage, LanguagesEnum[] languagesEnums);
    }
}
