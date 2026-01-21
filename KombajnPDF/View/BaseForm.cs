using KombajnPDF.App.Interface;
using KombajnPDF.Data.Entity;
using System.Windows.Forms;

namespace KombajnPDF.Classes.Form
{
    public partial class BaseForm : System.Windows.Forms.Form, IBaseFormView
    {
        public BaseForm()
        {
            InitializeComponent();

            this.Load += BaseForm_Load;
            this.Shown += BaseForm_Shown;
            this.FormClosed += BaseForm_FormClosed;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            // Automatyczne tłumaczenie po zmianie języka
            GlobalSettingsProvider.Instance.LanguageChanged += () =>
            {
                GlobalSettingsProvider.Instance.TranslateControl(this);
            };
            GlobalSettingsProvider.Instance.TranslateControl(this);
        }

        private void BaseForm_Shown(object sender, EventArgs e)
        {
            // Możesz dodać logowanie lub inne akcje
        }

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Możesz dodać logowanie lub inne akcje
        }

        public void ShowMessageBox(string message, string caption)
        {
            MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowYesNoMessageBox(string message, string caption, out bool isYesSelected)
        {
            var restult = MessageBox.Show(this, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            isYesSelected = restult is DialogResult.Yes;
        }

        /// <inheritdoc/>
        public string[] ShowOpenFileDialog()
        {
            SelectFilesOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return SelectFilesOpenFileDialog.ShowDialog() == DialogResult.OK
                ? SelectFilesOpenFileDialog.FileNames
                : Array.Empty<string>();
        }



        public void SetWaitCursor(bool isWaiting)
        {
            Cursor.Current = isWaiting ? Cursors.WaitCursor : Cursors.Default;
        }

        public virtual void ShowError(string message)
        {
            throw new NotImplementedException(message);
        }
    }
}
