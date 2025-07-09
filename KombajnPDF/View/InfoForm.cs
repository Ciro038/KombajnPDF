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
using System.IO;

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

            // Load license text from LICENSE.txt file
            LoadLicenseText();
            LoadOtherLicense();
        }

        /// <summary>
        /// Loads the license text from LICENSE.txt file into MainLicenseTextBox
        /// </summary>
        private void LoadLicenseText()
        {
            try
            {
                string licensePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LICENSE", "LICENSE.txt");
                if (File.Exists(licensePath))
                {
                    string licenseText = File.ReadAllText(licensePath, Encoding.UTF8);
                    MainLicenseTextBox.Text = licenseText;
                }
                else
                {
                    MainLicenseTextBox.Text = "License file not found.";
                }
            }
            catch (Exception ex)
            {
                MainLicenseTextBox.Text = $"Error loading license: {ex.Message}";
            }
        }

        private void LoadOtherLicense()
        {
            try
            {
                string otherLicensePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LICENSE", "THIRD-PARTY-NOTICES.txt");
                if (File.Exists(otherLicensePath))
                {
                    string otherLicenseText = File.ReadAllText(otherLicensePath, Encoding.UTF8);
                    OtherLicenseTextBox.Text = otherLicenseText;
                }
                else
                {
                    OtherLicenseTextBox.Text = "Other license file not found.";
                }
            }
            catch (Exception ex)
            {
                OtherLicenseTextBox.Text = $"Error loading other license: {ex.Message}";
            }
        }
    }
}
