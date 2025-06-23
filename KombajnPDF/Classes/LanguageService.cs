using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
using KombajnPDF.Properties.Translations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    public class LanguageService : ILanguageService
    {
        private LanguagesEnum _currentLanguage;

        // Lazy cache ResourceManagerów
        private readonly Dictionary<LanguagesEnum, ResourceManager> _resourceManagers = new();

        public LanguageService()
        {
            LoadCurrentLanguage();
        }

        public LanguagesEnum CurrentLanguage => _currentLanguage;

        private void LoadCurrentLanguage()
        {
            var language = GetLanguage();
            SetLanguage(language);
        }

        public LanguagesEnum GetLanguage()
        {
            if (Enum.TryParse(Properties.Settings.Default.Language, out LanguagesEnum lang))
                return lang;

            return LanguagesEnum.English; // domyślny fallback
        }

        public void SetLanguage(LanguagesEnum language)
        {
            _currentLanguage = language;
            Properties.Settings.Default.Language = language.ToString();
            Properties.Settings.Default.Save();
        }

        public string Translate(TranslationCodes translationCode)
        {
            if (!_resourceManagers.TryGetValue(_currentLanguage, out var manager))
            {
                string baseName = $"KombajnPDF.Properties.Translations.Strings.{_currentLanguage}";
                manager = new ResourceManager(baseName, typeof(LanguageService).Assembly);
                _resourceManagers[_currentLanguage] = manager;
            }

            string key = translationCode.ToString();
            return manager.GetString(key) ?? $"[{key}]";
        }

        public void TranslateControl(Control parent)
        {
            //TODO: sprawdzić czy w tym miejscu poprawnie się tłumaczy aplikacja
            if (parent.Tag is string code)
                parent.Text = Translate((TranslationCodes)Enum.Parse(typeof(TranslationCodes), code));

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag is string childCode)
                    ctrl.Text = Translate((TranslationCodes)Enum.Parse(typeof(TranslationCodes), childCode));

                if (ctrl.HasChildren)
                    TranslateControl(ctrl);
            }
        }
    }
}
