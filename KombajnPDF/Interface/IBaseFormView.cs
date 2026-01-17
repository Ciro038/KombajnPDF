namespace KombajnPDF.Interface
{
    interface IBaseFormView
    {
        void ShowMessageBox(string message, string caption);

        void ShowYesNoMessageBox(string message, string caption, out bool isYesSelected);

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

        /// <summary>
        /// Opens a file dialog and returns the selected file paths.
        /// </summary>
        /// <returns>An array of file paths selected by the user.</returns>
        string[] ShowOpenFileDialog();

        string ShowSaveFileDialogForPdfFile();

        void SetWaitCursor(bool isWaiting);
    }
}
