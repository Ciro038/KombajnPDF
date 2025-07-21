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

namespace KombajnPDF.Classes.Form
{
    public partial class BaseForm : System.Windows.Forms.Form
    {
        public BaseForm()
        {
            InitializeComponent();

            // Globalna obsługa wyjątków dla formularza
            this.Load += BaseForm_Load;
            this.Shown += BaseForm_Shown;
            this.FormClosed += BaseForm_FormClosed;
        }

        // Przykładowe zdarzenie: logowanie otwarcia formularza
        private void BaseForm_Load(object sender, EventArgs e)
        {
            // Automatyczne tłumaczenie po zmianie języka
            GlobalSettingsProvider.Instance.LanguageChanged += () =>
            {
                GlobalSettingsProvider.Instance.TranslateControl(this);
            };
            GlobalSettingsProvider.Instance.TranslateControl(this);
        }

        // Przykładowe zdarzenie: logowanie pokazania formularza
        private void BaseForm_Shown(object sender, EventArgs e)
        {
            // Możesz dodać logowanie lub inne akcje
        }

        // Przykładowe zdarzenie: logowanie zamknięcia formularza
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Możesz dodać logowanie lub inne akcje
        }

        ///// <summary>
        ///// Wyświetla komunikat o błędzie
        ///// </summary>
        //public void ShowError(string message, string? caption = null)
        //{
        //    MessageBox.Show(this, message, caption ?? "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        ///// <summary>
        ///// Wyświetla komunikat informacyjny
        ///// </summary>
        //public void ShowInfo(string message, string? caption = null)
        //{
        //    MessageBox.Show(this, message, caption ?? "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        ///// <summary>
        ///// Loguje wyjątek do pliku error.log w katalogu aplikacji
        ///// </summary>
        //public void LogException(Exception ex)
        //{
        //    try
        //    {
        //        string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
        //        string logEntry = $"[{DateTime.Now}] {ex}\n";
        //        File.AppendAllText(logPath, logEntry);
        //    }
        //    catch
        //    {
        //        // Jeśli logowanie się nie powiedzie, nie przerywaj działania aplikacji
        //    }
        //}
    }
}
