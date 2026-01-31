using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Interface
{
    /// <summary>
    /// Represents the interface for the settings form view in the application.
    /// It defines events and methods used for handling language settings.
    /// </summary>
    interface ISettingsFormView : IBaseFormView
    {
        /// <summary>
        /// Triggered when the settings form is loaded
        /// </summary>
        event Action LoadConfigs;

        /// <summary>
        /// Triggered when the user selects a different language from the settings form.
        /// </summary>
        event Action<LanguagesEnum> LanguageConfigChanged;
        event Action<bool> OpenFileAfterCombineConfigChanged;

        /// <summary>
        /// Sets the list of available languages in the form, highlighting the current one.
        /// </summary>
        /// <param name="currentLanguage">The currently selected language.</param>
        /// <param name="availableLanguages">Array of available language options.</param>
        void SetLanguagesConfig(LanguagesEnum currentLanguage, LanguagesEnum[] availableLanguages);
        void SetOpenFileAfterCombineConfig(bool openFileAfterCombine);

    }

}
