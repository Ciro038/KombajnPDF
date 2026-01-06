using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KombajnPDF.Interface
{
    interface IBaseFormView
    {
        void ShowMessageBox(string message, string caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon);
        void ShowErrorProvider(Control control, string message);

        void ShowErrorProvider(string message);
    }
}
