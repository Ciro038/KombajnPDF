using KombajnPDF.Classes;
using KombajnPDF.Data.Entity;
using KombajnPDF.Properties.Translations;

namespace KombajnPDF
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                LogUnhandledException(ex);
                MessageBox.Show(GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.UNEXPECTED_EXCEPTION_OCCURRED), GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.ERROR), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Logs unhandled exceptions to a log file in the application's directory.
        /// </summary>
        private static void LogUnhandledException(Exception ex)
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
            string logEntry = $"[{DateTime.Now}] {ex}\n";

            try
            {
                File.AppendAllText(logPath, logEntry);
            }
            catch
            {
                // If logging fails, avoid crashing further
            }
        }
    }
}