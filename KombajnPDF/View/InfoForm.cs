using KombajnPDF.App.Interface;
using KombajnPDF.App.Presenter;
using KombajnPDF.Classes.Form;

namespace KombajnPDF.View
{
    public partial class InfoForm : BaseForm, IInfoFormView
    {
        private InfoFormPresenter presenter;
        public event Action LoadData;

        public InfoForm() : base()
        {
            InitializeComponent();

            presenter = new InfoFormPresenter(this);
        }


        public void FillMainLicenseText(string pText)
        {
            MainLicenseTextBox.Text = pText;
        }

        public void FillOtherLicenseText(string pText)
        {
            OtherLicenseTextBox.Text = pText;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            LoadData?.Invoke();
        }
    }
}
