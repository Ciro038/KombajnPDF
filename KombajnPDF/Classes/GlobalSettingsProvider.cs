using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    public sealed class GlobalSettingsProvider
    {
        private static readonly Lazy<GlobalSettingsProvider> _instance =
            new Lazy<GlobalSettingsProvider>(() => new GlobalSettingsProvider());

        private LanguageService languageService;
        public static GlobalSettingsProvider Instance => _instance.Value;
        public LanguagesEnum CurrentLanguage
        {
            get => languageService.CurrentLanguage;
            set
            {
                languageService.SetLanguage(value);
                LanguageChanged?.Invoke();
            }
        }
        private GlobalSettingsProvider()
        {
            languageService = new LanguageService();
        }

        public event Action? LanguageChanged;

    }
}
