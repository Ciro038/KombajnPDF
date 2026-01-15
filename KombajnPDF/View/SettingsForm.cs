using KombajnPDF.Classes;
using KombajnPDF.Classes.Form;
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
    /// <summary>
    /// Represents the settings form used to manage global application settings such as language.
    /// Implements the ISettingsFormView interface.
    /// </summary>
    public partial class SettingsForm : BaseForm, ISettingsFormView
    {
        /// <summary>
        /// Presenter instance that handles logic between the view and model.
        /// </summary>
        private readonly SettingsFormPresenter presenter;

        /// <summary>
        /// Event triggered when the form should load available languages.
        /// </summary>
        public event Action LoadAvailableLanguages;

        /// <summary>
        /// Event triggered when the user selects a different language.
        /// </summary>
        public event Action<LanguagesEnum> LanguageChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsForm"/> class.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
            presenter = new SettingsFormPresenter(this);
        }

        /// <summary>
        /// Populates the language combo box with available languages and selects the current one.
        /// </summary>
        /// <param name="currentLanguage">The currently selected language.</param>
        /// <param name="languagesEnums">Array of all supported languages.</param>
        public void SetAvailableLanguages(LanguagesEnum currentLanguage, LanguagesEnum[] languagesEnums)
        {
            CurrentLanguageComboBox.Items.AddRange(languagesEnums.Cast<object>().ToArray());
            CurrentLanguageComboBox.SelectedItem = currentLanguage;
        }

        /// <summary>
        /// Event handler for when the selected language in the combo box changes.
        /// </summary>
        private void CurrentLanguageComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CurrentLanguageComboBox.SelectedItem is LanguagesEnum selectedLanguage)
            {
                LanguageChanged?.Invoke(selectedLanguage);
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadAvailableLanguages?.Invoke();
        }
    }

}
