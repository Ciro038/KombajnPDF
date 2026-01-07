using KombajnPDF.Data.Entity;
using KombajnPDF.Interface;

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

        public virtual void ShowMessageBox(string message, string caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            MessageBox.Show(this, message, caption, messageBoxButtons, messageBoxIcon);
        }

        public virtual void ShowErrorProvider(Control control, string message)
        {
            MainErrorProvider.SetError(control, message);
        }

        public virtual void ShowErrorProvider(string message)
        {
            MainErrorProvider.SetError(this, message);
        }
    }
}
