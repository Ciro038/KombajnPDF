using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interface
{
    public interface IGlobalSettingsProvider
    {
        LanguagesEnum CurrentLanguage { get; set; }
        event Action? LanguageChanged;
    }
}
