using KombajnPDF.Classes;
using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
using KombajnPDF.Properties.Translations;
using KombajnPDF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Presenter
{
    /// <summary>
    /// Presenter class responsible for managing the logic of the settings form,
    /// including language selection and handling user interactions.
    /// </summary>
    class SettingsFormPresenter
    {
        private readonly ISettingsFormView settingsForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsFormPresenter"/> class
        /// and subscribes to relevant events from the settings form view.
        /// </summary>
        /// <param name="settingsForm">The settings form view instance.</param>
        public SettingsFormPresenter(ISettingsFormView settingsForm)
        {
            this.settingsForm = settingsForm;

            settingsForm.LoadAvailableLanguages += OnLoadAvailableLanguages;
            settingsForm.LanguageChanged += OnLanguageChanged;
        }

        /// <summary>
        /// Event handler triggered when the user changes the application language.
        /// Updates the global settings and notifies the user.
        /// </summary>
        /// <param name="language">The new language selected by the user.</param>
        private void OnLanguageChanged(LanguagesEnum language)
        {
            if (language != GlobalSettingsProvider.Instance.CurrentLanguage)
            {
                GlobalSettingsProvider.Instance.CurrentLanguage = language;
                MessageBox.Show(GlobalSettingsProvider.Instance.Translate(TranslationCodes.LANGUAGE_CHANGED));
            }
        }

        /// <summary>
        /// Event handler triggered when the form requests the list of available languages.
        /// Loads all defined languages and updates the view.
        /// </summary>
        private void OnLoadAvailableLanguages()
        {
            var languages = Enum.GetValues(typeof(LanguagesEnum))
                .Cast<LanguagesEnum>()
                .ToArray();
            settingsForm.SetAvailableLanguages(GlobalSettingsProvider.Instance.CurrentLanguage, languages);
        }
    }

}
