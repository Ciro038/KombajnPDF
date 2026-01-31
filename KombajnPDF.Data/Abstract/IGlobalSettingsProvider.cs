using KombajnPDF.Data.Enum;
using KombajnPDF.Data.Translations;

namespace KombajnPDF.Data.Abstract
{
    /// <summary>
    /// Provides access to global application settings, such as the current language,
    /// and allows subscribing to language change notifications.
    /// </summary>
    public interface IGlobalSettingsProvider
    {
        /// <summary>
        /// Gets or sets the currently selected language in the application.
        /// Changing this value triggers the <see cref="LanguageChanged"/> event.
        /// </summary>
        LanguagesEnum CurrentLanguage { get; }
        bool OpenFileAfterCombine { get; }
        bool TryChangeOpenFileAfterCombine(bool openFileAfterCombine);
        string TranslateCode(TranslationCodes translationCode);
        void TranslateControl(Control parent);
        bool TryChangeCurrentLanguage(LanguagesEnum language);
        (LanguagesEnum currentLanguage, LanguagesEnum[] availableLanguages) GetLanguages();
        bool GetOpenFileAfterCombine();
        /// <summary>
        /// Event that is raised when the <see cref="CurrentLanguage"/> is changed.
        /// </summary>
        event Action? LanguageChanged;
    }
}
