using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Entity
{
    class LanguageService : ILanguageService
    {
        private LanguagesEnum _currentLanguage;

        private static readonly Dictionary<LanguagesEnum, ResourceManager> _resourceManagers =
            new Dictionary<LanguagesEnum, ResourceManager>();

        public LanguageService()
        {
            LoadCurrentLanguage();
            LoadTranslationsResources();
        }

        private void LoadTranslationsResources()
        {
            foreach (LanguagesEnum lang in System.Enum.GetValues(typeof(LanguagesEnum)))
            {
                string baseName = $"KombajnPDF.Properties.Translations.Strings.{lang}";
                var rm = new ResourceManager(baseName, typeof(LanguageService).Assembly);
                _resourceManagers[lang] = rm;
            }
        }

        public LanguagesEnum CurrentLanguage => _currentLanguage;
        private void LoadCurrentLanguage()
        {
            LanguagesEnum language = (LanguagesEnum)System.Enum.Parse(typeof(LanguagesEnum), Properties.Settings.Default.Language);
            _currentLanguage = language;
        }
        public void SetLanguage(LanguagesEnum language)
        {
            _currentLanguage = language;
            Properties.Settings.Default.Language = language.ToString();
        }

        public static string Translate(string key)
        {
            var lang = GlobalSettingsProvider.Instance.CurrentLanguage;
            if (_resourceManagers.TryGetValue(lang, out var manager))
            {
                var test = manager.GetString(key) ?? $"[{key}]";
                return manager.GetString(key) ?? $"[{key}]";
            }
            return $"[{key}]";
        }

        public static void LocalizeForm(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag is string tag)
                    ctrl.Text = Translate(tag);

                if (ctrl.HasChildren)
                    LocalizeForm(ctrl);
            }
        }
    }
}
