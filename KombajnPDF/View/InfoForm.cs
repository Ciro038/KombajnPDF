using KombajnPDF.Classes;
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
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();

            GlobalSettingsProvider.Instance.LanguageChanged += () =>
            {
                GlobalSettingsProvider.Instance.TranslateControl(this);
            };

            GlobalSettingsProvider.Instance.TranslateControl(this);

            InfoTextBox.Text = GlobalSettingsProvider.Instance.TranslateCode(Properties.Translations.TranslationCodes.INFORMATION_ABOUT_APPLICATION_TEXT);
            InstructionTextBox.Text = GlobalSettingsProvider.Instance.TranslateCode(Properties.Translations.TranslationCodes.INSTRUCTION_MANUAL_TEXT);
        }
    }
}
