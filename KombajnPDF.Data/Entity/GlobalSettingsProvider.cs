using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using KombajnPDF.Data.Translations;
using Windows.Globalization;

namespace KombajnPDF.Data.Entity
{
    /// <summary>
    /// Singleton class that manages global application settings,
    /// such as:
    /// - current language
    /// - translation functionality
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
        public static IGlobalSettingsProvider Instance => _instance.Value;

        private readonly ILanguageService _languageService;
        /// <summary>
        /// Gets or sets the current application language.
        /// Raises <see cref="LanguageChanged"/> event when the value changes.
        /// </summary>
        public LanguagesEnum CurrentLanguage
        {
            get => _languageService.CurrentLanguage;
        }

        public bool OpenFileAfterCombine { get; private set; }

        private GlobalSettingsProvider()
        {
            _languageService = new LanguageService();
            OpenFileAfterCombine = GetOpenFileAfterCombine();
        }

        /// <summary>
        /// Translates a given <see cref="TranslationCodes"/> enum value to the corresponding localized string.
        /// </summary>
        /// <param name="translationCode">The translation code to be translated.</param>
        /// <returns>Localized string based on the current language.</returns>
        public string TranslateCode(TranslationCodes translationCode) => _languageService.Translate(translationCode);

        /// <summary>
        /// Recursively applies translation to a control and all its children based on their Tag properties.
        /// </summary>
        /// <param name="control">The root control to translate.</param>
        public void TranslateControl(Control control) => _languageService.TranslateControl(control);

        public bool TryChangeOpenFileAfterCombine(bool openFileAfterCombine)
        {
            if (!OpenFileAfterCombine.Equals(openFileAfterCombine))
            {
                Properties.Settings.Default.OpenFileAfterCombine = openFileAfterCombine.ToString();
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }

        public bool TryChangeCurrentLanguage(LanguagesEnum language)
        {
            if (_languageService.CurrentLanguage != language)
            {
                _languageService.SetLanguage(language);
                LanguageChanged?.Invoke();
                return true;
            }
            return false;
        }

        public (LanguagesEnum currentLanguage, LanguagesEnum[] availableLanguages) GetLanguages()
        {
            return (CurrentLanguage, _languageService.GetAvailableLanguages());
        }

        public bool GetOpenFileAfterCombine()
        {
            if (bool.TryParse(Properties.Settings.Default.OpenFileAfterCombine, out var result))
            {
                return result;
            }

            Properties.Settings.Default.OpenFileAfterCombine = true.ToString();
            Properties.Settings.Default.Save();
            return true;
        }

        /// <summary>
        /// Event that is triggered when the <see cref="CurrentLanguage"/> changes.
        /// </summary>
        public event Action? LanguageChanged;
    }
}
