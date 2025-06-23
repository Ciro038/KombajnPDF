using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
using KombajnPDF.Properties.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    /// <summary>
    /// Singleton class that manages global application settings,
    /// such as the current language and translation functionality.
    /// Implements the <see cref="IGlobalSettingsProvider"/> interface.
    /// </summary>
    public sealed class GlobalSettingsProvider : IGlobalSettingsProvider
    {
        // Lazy-initialized singleton instance of the class.
        private static readonly Lazy<GlobalSettingsProvider> _instance =
            new Lazy<GlobalSettingsProvider>(() => new GlobalSettingsProvider());

        /// <summary>
        /// Gets the singleton instance of the <see cref="GlobalSettingsProvider"/>.
        /// </summary>
        public static GlobalSettingsProvider Instance => _instance.Value;

        private readonly ILanguageService _languageService;

        /// <summary>
        /// Gets or sets the current application language.
        /// Raises <see cref="LanguageChanged"/> event when the value changes.
        /// </summary>
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

        // Private constructor to prevent external instantiation.
        private GlobalSettingsProvider()
        {
            _languageService = new LanguageService();
        }

        /// <summary>
        /// Translates a given <see cref="TranslationCodes"/> enum value to the corresponding localized string.
        /// </summary>
        /// <param name="translationCode">The translation code to be translated.</param>
        /// <returns>Localized string based on the current language.</returns>
        public string Translate(TranslationCodes translationCode) => _languageService.Translate(translationCode);

        /// <summary>
        /// Recursively applies translation to a control and all its children based on their Tag properties.
        /// </summary>
        /// <param name="control">The root control to translate.</param>
        public void TranslateControl(Control control) => _languageService.TranslateControl(control);

        /// <summary>
        /// Event that is triggered when the <see cref="CurrentLanguage"/> changes.
        /// </summary>
        public event Action? LanguageChanged;
    }
}
