using KombajnPDF.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        LanguagesEnum CurrentLanguage { get; set; }

        /// <summary>
        /// Event that is raised when the <see cref="CurrentLanguage"/> is changed.
        /// </summary>
        event Action? LanguageChanged;
    }
}
