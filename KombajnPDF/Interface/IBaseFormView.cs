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
        /// <summary>
        /// Displays a message box to the user with the specified text, title, buttons, and icon.
        /// </summary>
        /// <param name="message">The text to display in the message box.</param>
        /// <param name="caption">The caption (title) shown in the message box window.</param>
        /// <param name="messageBoxButtons">Specifies which buttons to display (for example, OK, OKCancel, YesNo).</param>
        /// <param name="messageBoxIcon">Specifies the icon to display (for example, Information, Warning, Error).</param>
        void ShowMessageBox(string message, string caption, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon);
        /// <summary>
        /// Sets or clears an error message associated with a specific control.
        /// When <paramref name="message"/> is non-empty, the implementing view should display the error
        /// next to or on the provided <paramref name="control"/> (for example using an <c>ErrorProvider</c>).
        /// When <paramref name="message"/> is <c>null</c> or empty, the implementing view should clear any error for that control.
        /// </summary>
        /// <param name="control">The control to associate the error message with. Implementations should handle <c>null</c> gracefully.</param>
        /// <param name="message">The error message to display for the control, or <c>null</c>/<see cref="string.Empty"/> to clear the error.</param>
        void ShowErrorProvider(Control control, string message);

        /// <summary>
        /// Displays or clears a non-control-specific error message on the form.
        /// Use this overload to show a form-level error summary, tooltip, or other global error indicator.
        /// When <paramref name="message"/> is <c>null</c> or empty, the implementing view should clear the form-level error display.
        /// </summary>
        /// <param name="message">The error message to display, or <c>null</c>/<see cref="string.Empty"/> to clear the form-level error.</param>
        void ShowErrorProvider(string message);
    }
}
