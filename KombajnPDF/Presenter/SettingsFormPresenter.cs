using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
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
        private readonly ILanguageService languageService;
        public SettingsFormPresenter(ISettingsFormView settingsForm, ILanguageService languageService)
        {
            this.settingsForm = settingsForm;
            this.languageService = languageService;

            settingsForm.LoadAvailableLanguages += OnLoadAvailableLanguages;
            settingsForm.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(LanguagesEnum language)
        {
            languageService.ChangeLanguage(language);
        }

        private void OnLoadAvailableLanguages()
        {
            var languages = Enum.GetValues(typeof(LanguagesEnum))
                .Cast<LanguagesEnum>()
                .ToArray();
            settingsForm.SetAvailableLanguages(languageService.CurrentLanguage, languages);
        }
    }
}
