using KombajnPDF.App.Interface;
using KombajnPDF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.App.Presenter
{
    class InfoFormPresenter
    {
        private readonly IInfoFormView _view;

        public InfoFormPresenter(IInfoFormView pMainForm)
        {
            _view = pMainForm;
            _view.LoadData += LoadData;
        }

        private void LoadData()
        {
            LoadMainLicenseText();
            LoadOtherLicense();
        }

        private void LoadOtherLicense()
        {
            string text = null;
            try
            {
                string otherLicensePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LICENSE", "THIRD-PARTY-NOTICES.txt");
                if (File.Exists(otherLicensePath))
                {
                    string otherLicenseText = File.ReadAllText(otherLicensePath, Encoding.UTF8);
                    text = otherLicenseText;
                }
                else
                {
                    text = "Other license file not found.";
                }
            }
            catch (Exception ex)
            {
                text = $"Error loading other license: {ex.Message}";
            }
            _view.FillOtherLicenseText(text);
        }

        /// <summary>
        /// Loads the license text from LICENSE.txt file into MainLicenseTextBox
        /// </summary>
        private void LoadMainLicenseText()
        {
            string text = null;
            try
            {
                string licensePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LICENSE", "LICENSE.txt");
                if (File.Exists(licensePath))
                {
                    string licenseText = File.ReadAllText(licensePath, Encoding.UTF8);
                    text = licenseText;
                }
                else
                {
                    text = "License file not found.";
                }
            }
            catch (Exception ex)
            {
                text = $"Error loading license: {ex.Message}";
            }
            _view.FillMainLicenseText(text);
        }
    }
}
