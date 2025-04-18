using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Entity
{
    class LanguageService : ILanguageService
    {
        private LanguagesEnum _currentLanguage;
        public LanguageService()
        {
            LoadCurrentLanguage();
        }

        public LanguagesEnum CurrentLanguage => _currentLanguage;

        public void ChangeLanguage(LanguagesEnum language)
        {
            _currentLanguage = language;
            Properties.Settings.Default.Language = language.ToString();
        }

        private void LoadCurrentLanguage()
        {
            LanguagesEnum language = (LanguagesEnum)System.Enum.Parse(typeof(LanguagesEnum), Properties.Settings.Default.Language);
            _currentLanguage = language;
        }
    }
}
