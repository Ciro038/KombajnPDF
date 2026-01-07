using KombajnPDF.Data.Enum;
using KombajnPDF.Properties.Translations;

namespace KombajnPDF.Data.Abstract
{
    /// <summary>
    /// Provides language-related services such as retrieving translations 
    /// and applying them to UI controls.
    /// </summary>
    public interface ILanguageService
    {
        /// <summary>
        /// Gets the currently selected language.
        /// </summary>
        LanguagesEnum CurrentLanguage { get; }

        /// <summary>
        /// Sets the application language to the specified value.
        /// Updates the internal state and can be used to trigger translation updates.
        /// </summary>
        /// <param name="language">The language to set as current.</param>
        void SetLanguage(LanguagesEnum language);

        /// <summary>
        /// Translates a given translation code into the current language.
        /// </summary>
        /// <param name="translationCode">The translation code representing a specific phrase or label.</param>
        /// <returns>The translated string.</returns>
        string Translate(TranslationCodes translationCode);

        /// <summary>
        /// Recursively applies translations to a control and its child controls based on the control's <c>Tag</c> property.
        /// </summary>
        /// <param name="control">The root control to apply translations to.</param>
        void TranslateControl(Control control);
    }
}
