namespace KombajnPDF.View
{
    partial class InfoForm
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
            MainInfoTabControl = new TabControl();
            InfoTabPage = new TabPage();
            LicenseTabPage = new TabPage();
            MainInfoTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // MainInfoTabControl
            // 
            MainInfoTabControl.Controls.Add(InfoTabPage);
            MainInfoTabControl.Controls.Add(LicenseTabPage);
            MainInfoTabControl.Dock = DockStyle.Fill;
            MainInfoTabControl.Location = new Point(0, 0);
            MainInfoTabControl.Name = "MainInfoTabControl";
            MainInfoTabControl.SelectedIndex = 0;
            MainInfoTabControl.Size = new Size(800, 450);
            MainInfoTabControl.TabIndex = 0;
            // 
            // InfoTabPage
            // 
            InfoTabPage.Location = new Point(4, 24);
            InfoTabPage.Name = "InfoTabPage";
            InfoTabPage.Padding = new Padding(3);
            InfoTabPage.Size = new Size(792, 422);
            InfoTabPage.TabIndex = 0;
            InfoTabPage.Text = "INFO";
            InfoTabPage.UseVisualStyleBackColor = true;
            // 
            // LicenseTabPage
            // 
            LicenseTabPage.Location = new Point(4, 24);
            LicenseTabPage.Name = "LicenseTabPage";
            LicenseTabPage.Padding = new Padding(3);
            LicenseTabPage.Size = new Size(792, 422);
            LicenseTabPage.TabIndex = 1;
            LicenseTabPage.Text = "LICENSE";
            LicenseTabPage.UseVisualStyleBackColor = true;
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainInfoTabControl);
            Name = "InfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InfoForm";
            MainInfoTabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl MainInfoTabControl;
        private TabPage InfoTabPage;
        private TabPage LicenseTabPage;
    }
}