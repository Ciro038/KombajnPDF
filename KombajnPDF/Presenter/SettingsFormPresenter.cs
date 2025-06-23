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
    class SettingsFormPresenter
    {
        private readonly ISettingsFormView settingsForm;
        public SettingsFormPresenter(ISettingsFormView settingsForm)
        {
            this.settingsForm = settingsForm;

            settingsForm.LoadAvailableLanguages += OnLoadAvailableLanguages;
            settingsForm.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(LanguagesEnum language)
        {
            if (language != GlobalSettingsProvider.Instance.CurrentLanguage)
            {
                GlobalSettingsProvider.Instance.CurrentLanguage = language;
                MessageBox.Show(GlobalSettingsProvider.Instance.Translate(TranslationCodes.LANGUAGE_CHANGED));
            }
        }

        private void OnLoadAvailableLanguages()
        {
            var languages = Enum.GetValues(typeof(LanguagesEnum))
                .Cast<LanguagesEnum>()
                .ToArray();
            settingsForm.SetAvailableLanguages(GlobalSettingsProvider.Instance.CurrentLanguage, languages);
        }
    }
}
