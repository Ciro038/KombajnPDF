using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    public sealed class GlobalSettingsProvider : IGlobalSettingsProvider
    {
        private static readonly Lazy<GlobalSettingsProvider> _instance =
            new Lazy<GlobalSettingsProvider>(() => new GlobalSettingsProvider());

        public static GlobalSettingsProvider Instance => _instance.Value;

        private readonly ILanguageService _languageService;

        public LanguagesEnum CurrentLanguage
        {
            get => _languageService.CurrentLanguage;
            set
            {
                if (_languageService.CurrentLanguage != value)
                {
                    _languageService.SetLanguage(value);
                    LanguageChanged?.Invoke();
                }
            }
        }

        private GlobalSettingsProvider()
        {
            _languageService = new LanguageService();
        }

        public string Translate(string key) => _languageService.Translate(key);

        public void TranslateControl(Control control) => _languageService.TranslateControl(control);

        public event Action? LanguageChanged;
    }
}
