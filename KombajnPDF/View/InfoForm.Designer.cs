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
            InstructionGroupBox = new GroupBox();
            InfoGroupBox = new GroupBox();
            LicenseTabPage = new TabPage();
            OtherLicenseGroupBox = new GroupBox();
            MainLicenseGroupBox = new GroupBox();
            MainInfoTabControl.SuspendLayout();
            InfoTabPage.SuspendLayout();
            LicenseTabPage.SuspendLayout();
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
            MainInfoTabControl.Size = new Size(615, 450);
            MainInfoTabControl.TabIndex = 0;
            // 
            // InfoTabPage
            // 
            InfoTabPage.Controls.Add(InstructionGroupBox);
            InfoTabPage.Controls.Add(InfoGroupBox);
            InfoTabPage.Location = new Point(4, 24);
            InfoTabPage.Name = "InfoTabPage";
            InfoTabPage.Padding = new Padding(3);
            InfoTabPage.Size = new Size(607, 422);
            InfoTabPage.TabIndex = 0;
            InfoTabPage.Text = "INFO";
            InfoTabPage.UseVisualStyleBackColor = true;
            // 
            // InstructionGroupBox
            // 
            InstructionGroupBox.Dock = DockStyle.Fill;
            InstructionGroupBox.Location = new Point(3, 185);
            InstructionGroupBox.Name = "InstructionGroupBox";
            InstructionGroupBox.Size = new Size(601, 234);
            InstructionGroupBox.TabIndex = 0;
            InstructionGroupBox.TabStop = false;
            InstructionGroupBox.Text = "INSTRUCTION";
            // 
            // InfoGroupBox
            // 
            InfoGroupBox.Dock = DockStyle.Top;
            InfoGroupBox.Location = new Point(3, 3);
            InfoGroupBox.Name = "InfoGroupBox";
            InfoGroupBox.Size = new Size(601, 182);
            InfoGroupBox.TabIndex = 1;
            InfoGroupBox.TabStop = false;
            InfoGroupBox.Text = "INFO";
            // 
            // LicenseTabPage
            // 
            LicenseTabPage.Controls.Add(OtherLicenseGroupBox);
            LicenseTabPage.Controls.Add(MainLicenseGroupBox);
            LicenseTabPage.Location = new Point(4, 24);
            LicenseTabPage.Name = "LicenseTabPage";
            LicenseTabPage.Padding = new Padding(3);
            LicenseTabPage.Size = new Size(607, 422);
            LicenseTabPage.TabIndex = 1;
            LicenseTabPage.Text = "LICENSE";
            LicenseTabPage.UseVisualStyleBackColor = true;
            // 
            // OtherLicenseGroupBox
            // 
            OtherLicenseGroupBox.Dock = DockStyle.Fill;
            OtherLicenseGroupBox.Location = new Point(3, 179);
            OtherLicenseGroupBox.Name = "OtherLicenseGroupBox";
            OtherLicenseGroupBox.Size = new Size(601, 240);
            OtherLicenseGroupBox.TabIndex = 1;
            OtherLicenseGroupBox.TabStop = false;
            OtherLicenseGroupBox.Text = "OTHER LICENSE";
            // 
            // MainLicenseGroupBox
            // 
            MainLicenseGroupBox.Dock = DockStyle.Top;
            MainLicenseGroupBox.Location = new Point(3, 3);
            MainLicenseGroupBox.Name = "MainLicenseGroupBox";
            MainLicenseGroupBox.Size = new Size(601, 176);
            MainLicenseGroupBox.TabIndex = 0;
            MainLicenseGroupBox.TabStop = false;
            MainLicenseGroupBox.Text = "MAIN LICENSE";
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 450);
            Controls.Add(MainInfoTabControl);
            Name = "InfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InfoForm";
            MainInfoTabControl.ResumeLayout(false);
            InfoTabPage.ResumeLayout(false);
            LicenseTabPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl MainInfoTabControl;
        private TabPage InfoTabPage;
        private TabPage LicenseTabPage;
        private GroupBox InstructionGroupBox;
        private GroupBox InfoGroupBox;
        private GroupBox OtherLicenseGroupBox;
        private GroupBox MainLicenseGroupBox;
    }
}