using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interface
{
    public interface ILanguageService
    {
        LanguagesEnum CurrentLanguage { get; }
        void SetLanguage(LanguagesEnum language);
        string Translate(string key);
        void TranslateControl(Control control);
    }
}
