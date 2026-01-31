using KombajnPDF.App.Interface;
using KombajnPDF.Data.Entity;
using KombajnPDF.Data.Enum;
using KombajnPDF.Data.Translations;
using KombajnPDF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization;

namespace KombajnPDF.App.Presenter
{
    /// <summary>
    /// Presenter class responsible for managing the logic of the settings form,
    /// including language selection and handling user interactions.
    /// </summary>
    class SettingsFormPresenter
    {
        private readonly ISettingsFormView settingsFormView;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsFormPresenter"/> class
        /// and subscribes to relevant events from the settings form view.
        /// </summary>
        /// <param name="settingsForm">The settings form view instance.</param>
        public SettingsFormPresenter(ISettingsFormView settingsForm)
        {
            settingsFormView = settingsForm;

            settingsForm.LoadConfigs += OnLoadConfigs;
            settingsForm.LanguageConfigChanged += OnLanguageConfigChanged;
            settingsForm.OpenFileAfterCombineConfigChanged += OnOpenFileAfterCombineConfigChanged;
        }

        private void OnOpenFileAfterCombineConfigChanged(bool openFileAfterCombine)
        {
            if (GlobalSettingsProvider.Instance.TryChangeOpenFileAfterCombine(openFileAfterCombine))
            {
                settingsFormView.ShowMessageBox(GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.SETTING_CHANGED), GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.INFORMATION));
            }
        }

        /// <summary>
        /// Event handler triggered when the user changes the application language.
        /// Updates the global settings and notifies the user.
        /// </summary>
        /// <param name="language">The new language selected by the user.</param>
        private void OnLanguageConfigChanged(LanguagesEnum language)
        {
            if (GlobalSettingsProvider.Instance.TryChangeCurrentLanguage(language))
            {
                settingsFormView.ShowMessageBox(GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.SETTING_CHANGED), GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.INFORMATION));
            }
        }

        /// <summary>
        /// Event handler triggered when the form requests the list of available languages.
        /// Loads all defined languages and updates the view.
        /// </summary>
        private void OnLoadConfigs()
        {
            //TODO: do refaktoryzacji

            //pobranie języków
            var (currentLanguage, availableLanguages) = GlobalSettingsProvider.Instance.GetLanguages();

            //ustawienie języków w kontrolce
            settingsFormView.SetLanguagesConfig(currentLanguage, availableLanguages);

            //pobranie ustawienia otwierania pliku po połączeniu
            var openFileAfterCombine = GlobalSettingsProvider.Instance.GetOpenFileAfterCombine();

            //ustawienie w kontrolce ustawienia otwierania pliku po połączeniu
            settingsFormView.SetOpenFileAfterCombineConfig(openFileAfterCombine);
        }
    }

}
