using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interface
{
    /// <summary>
    /// Represents the interface for the settings form view in the application.
    /// It defines events and methods used for handling language settings.
    /// </summary>
    interface ISettingsFormView : IBaseFormView
    {
        /// <summary>
        /// Triggered when the settings form is loaded and available languages should be retrieved.
        /// </summary>
        event Action LoadAvailableLanguages;

        /// <summary>
        /// Triggered when the user selects a different language from the settings form.
        /// </summary>
        event Action<LanguagesEnum> LanguageChanged;

        /// <summary>
        /// Sets the list of available languages in the form, highlighting the current one.
        /// </summary>
        /// <param name="currentLanguage">The currently selected language.</param>
        /// <param name="languagesEnums">Array of available language options.</param>
        void SetAvailableLanguages(LanguagesEnum currentLanguage, LanguagesEnum[] languagesEnums);
    }

}
