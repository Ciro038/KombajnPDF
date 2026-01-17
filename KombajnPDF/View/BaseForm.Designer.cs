namespace KombajnPDF.Classes.Form
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            MainErrorProvider = new ErrorProvider(components);
            SelectFilesOpenFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // MainErrorProvider
            // 
            MainErrorProvider.ContainerControl = this;
            // 
            // SelectFilesOpenFileDialog
            // 
            SelectFilesOpenFileDialog.Multiselect = true;
            SelectFilesOpenFileDialog.RestoreDirectory = true;
            SelectFilesOpenFileDialog.Title = "Select files";
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "BaseForm";
            Text = "BaseForm";
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ErrorProvider MainErrorProvider;
        private OpenFileDialog SelectFilesOpenFileDialog;
    }
}