using KombajnPDF.Classes;
using KombajnPDF.Classes.Form;
using KombajnPDF.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KombajnPDF.View
{
    public partial class InfoForm : BaseForm, IInfoFormView
    {
        private Presenter.InfoFormPresenter presenter;
        public event Action LoadData;

        public InfoForm() : base()
        {
            InitializeComponent();

            presenter = new Presenter.InfoFormPresenter(this);
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
