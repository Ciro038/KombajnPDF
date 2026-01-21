namespace KombajnPDF.App.Interface
{
    public interface IBaseFormView
    {
        void ShowMessageBox(string message, string caption);

        void ShowYesNoMessageBox(string message, string caption, out bool isYesSelected);

        void ShowError(string message);

        /// <summary>
        /// Opens a file dialog and returns the selected file paths.
        /// </summary>
        /// <returns>An array of file paths selected by the user.</returns>
        string[] ShowOpenFileDialog();

        void SetWaitCursor(bool isWaiting);
    }
}
