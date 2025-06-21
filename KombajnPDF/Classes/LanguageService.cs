using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
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

        public string Translate(string key)
        {
            var lang = _currentLanguage;

            if (!_resourceManagers.TryGetValue(lang, out var manager))
            {
                string baseName = $"KombajnPDF.Properties.Translations.Strings.{lang}";
                manager = new ResourceManager(baseName, typeof(LanguageService).Assembly);
                _resourceManagers[lang] = manager;
            }

            string? result = manager.GetString(key);
            return result ?? $"[{key}]";
        }

        public void TranslateControl(Control parent)
        {
            if (parent.Tag is string tag1)
                parent.Text = Translate(tag1);

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag is string tag2)
                    ctrl.Text = Translate(tag2);

                if (ctrl.HasChildren)
                    TranslateControl(ctrl);
            }
        }
    }
}
