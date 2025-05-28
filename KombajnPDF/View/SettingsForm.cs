using KombajnPDF.Classes;
using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
using KombajnPDF.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KombajnPDF.View
{
    public partial class SettingsForm : Form, ISettingsFormView
    {
        private readonly SettingsFormPresenter presenter;
        public event Action LoadAvailableLanguages;

        public event Action<LanguagesEnum> LanguageChanged;
        public SettingsForm()
        {
            InitializeComponent();
            //this.languageService = languageService;

            presenter = new SettingsFormPresenter(this);

            LoadAvailableLanguages();

            GlobalSettingsProvider.Instance.LanguageChanged += () =>
            {
                LanguageService.TranslateControl(this);
            };

            LanguageService.TranslateControl(this);
        }

        public void SetAvailableLanguages(LanguagesEnum currentLanguage, LanguagesEnum[] languagesEnums)
        {
            CurrentLanguageComboBox.Items.AddRange(languagesEnums.Cast<object>().ToArray());
            CurrentLanguageComboBox.SelectedItem = currentLanguage;
        }

        private void CurrentLanguageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LanguageChanged((LanguagesEnum)CurrentLanguageComboBox.SelectedItem);
        }
    }
}
