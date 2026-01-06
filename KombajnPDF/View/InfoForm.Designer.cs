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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
            MainInfoTabControl = new TabControl();
            InfoTabPage = new TabPage();
            InstructionGroupBox = new GroupBox();
            InstructionTextBox = new TextBox();
            InfoGroupBox = new GroupBox();
            InfoTextBox = new TextBox();
            LicenseTabPage = new TabPage();
            OtherLicenseGroupBox = new GroupBox();
            OtherLicenseTextBox = new TextBox();
            MainLicenseGroupBox = new GroupBox();
            MainLicenseTextBox = new TextBox();
            MainInfoTabControl.SuspendLayout();
            InfoTabPage.SuspendLayout();
            InstructionGroupBox.SuspendLayout();
            InfoGroupBox.SuspendLayout();
            LicenseTabPage.SuspendLayout();
            OtherLicenseGroupBox.SuspendLayout();
            MainLicenseGroupBox.SuspendLayout();
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
            MainInfoTabControl.Size = new Size(716, 496);
            MainInfoTabControl.TabIndex = 0;
            // 
            // InfoTabPage
            // 
            InfoTabPage.Controls.Add(InstructionGroupBox);
            InfoTabPage.Controls.Add(InfoGroupBox);
            InfoTabPage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InfoTabPage.Location = new Point(4, 24);
            InfoTabPage.Name = "InfoTabPage";
            InfoTabPage.Padding = new Padding(3);
            InfoTabPage.Size = new Size(607, 422);
            InfoTabPage.TabIndex = 0;
            InfoTabPage.Tag = "INFORMATION";
            InfoTabPage.Text = "INFO";
            InfoTabPage.UseVisualStyleBackColor = true;
            // 
            // InstructionGroupBox
            // 
            InstructionGroupBox.Controls.Add(InstructionTextBox);
            InstructionGroupBox.Dock = DockStyle.Fill;
            InstructionGroupBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            InstructionGroupBox.Location = new Point(3, 209);
            InstructionGroupBox.Name = "InstructionGroupBox";
            InstructionGroupBox.Size = new Size(601, 210);
            InstructionGroupBox.TabIndex = 0;
            InstructionGroupBox.TabStop = false;
            InstructionGroupBox.Tag = "INSTRUCTION_MANUAL";
            InstructionGroupBox.Text = "INSTRUCTION";
            // 
            // InstructionTextBox
            // 
            InstructionTextBox.Dock = DockStyle.Fill;
            InstructionTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            InstructionTextBox.Location = new Point(3, 23);
            InstructionTextBox.Multiline = true;
            InstructionTextBox.Name = "InstructionTextBox";
            InstructionTextBox.ReadOnly = true;
            InstructionTextBox.ScrollBars = ScrollBars.Both;
            InstructionTextBox.Size = new Size(595, 184);
            InstructionTextBox.TabIndex = 1;
            InstructionTextBox.Tag = "INSTRUCTION_MANUAL_TEXT";
            // 
            // InfoGroupBox
            // 
            InfoGroupBox.Controls.Add(InfoTextBox);
            InfoGroupBox.Dock = DockStyle.Top;
            InfoGroupBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            InfoGroupBox.Location = new Point(3, 3);
            InfoGroupBox.Name = "InfoGroupBox";
            InfoGroupBox.Size = new Size(601, 206);
            InfoGroupBox.TabIndex = 1;
            InfoGroupBox.TabStop = false;
            InfoGroupBox.Tag = "INFORMATION_ABOUT_APPLICATION";
            InfoGroupBox.Text = "INFO";
            // 
            // InfoTextBox
            // 
            InfoTextBox.Dock = DockStyle.Fill;
            InfoTextBox.Location = new Point(3, 23);
            InfoTextBox.Multiline = true;
            InfoTextBox.Name = "InfoTextBox";
            InfoTextBox.ReadOnly = true;
            InfoTextBox.ScrollBars = ScrollBars.Both;
            InfoTextBox.Size = new Size(595, 180);
            InfoTextBox.TabIndex = 0;
            InfoTextBox.Tag = "INFORMATION_ABOUT_APPLICATION_TEXT";
            // 
            // LicenseTabPage
            // 
            LicenseTabPage.Controls.Add(OtherLicenseGroupBox);
            LicenseTabPage.Controls.Add(MainLicenseGroupBox);
            LicenseTabPage.Location = new Point(4, 24);
            LicenseTabPage.Name = "LicenseTabPage";
            LicenseTabPage.Padding = new Padding(3);
            LicenseTabPage.Size = new Size(708, 468);
            LicenseTabPage.TabIndex = 1;
            LicenseTabPage.Tag = "LICENSE";
            LicenseTabPage.Text = "LICENSE";
            LicenseTabPage.UseVisualStyleBackColor = true;
            // 
            // OtherLicenseGroupBox
            // 
            OtherLicenseGroupBox.Controls.Add(OtherLicenseTextBox);
            OtherLicenseGroupBox.Dock = DockStyle.Fill;
            OtherLicenseGroupBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            OtherLicenseGroupBox.Location = new Point(3, 209);
            OtherLicenseGroupBox.Name = "OtherLicenseGroupBox";
            OtherLicenseGroupBox.Size = new Size(702, 256);
            OtherLicenseGroupBox.TabIndex = 1;
            OtherLicenseGroupBox.TabStop = false;
            OtherLicenseGroupBox.Tag = "EXTERNAL_COMPONENT_LICENSE";
            OtherLicenseGroupBox.Text = "OTHER LICENSE";
            // 
            // OtherLicenseTextBox
            // 
            OtherLicenseTextBox.Dock = DockStyle.Fill;
            OtherLicenseTextBox.Location = new Point(3, 23);
            OtherLicenseTextBox.Multiline = true;
            OtherLicenseTextBox.Name = "OtherLicenseTextBox";
            OtherLicenseTextBox.ReadOnly = true;
            OtherLicenseTextBox.ScrollBars = ScrollBars.Both;
            OtherLicenseTextBox.Size = new Size(696, 230);
            OtherLicenseTextBox.TabIndex = 1;
            // 
            // MainLicenseGroupBox
            // 
            MainLicenseGroupBox.Controls.Add(MainLicenseTextBox);
            MainLicenseGroupBox.Dock = DockStyle.Top;
            MainLicenseGroupBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            MainLicenseGroupBox.Location = new Point(3, 3);
            MainLicenseGroupBox.Name = "MainLicenseGroupBox";
            MainLicenseGroupBox.Size = new Size(702, 206);
            MainLicenseGroupBox.TabIndex = 0;
            MainLicenseGroupBox.TabStop = false;
            MainLicenseGroupBox.Tag = "MAIN_LICENSE";
            MainLicenseGroupBox.Text = "MAIN LICENSE";
            // 
            // MainLicenseTextBox
            // 
            MainLicenseTextBox.Dock = DockStyle.Fill;
            MainLicenseTextBox.Location = new Point(3, 23);
            MainLicenseTextBox.Multiline = true;
            MainLicenseTextBox.Name = "MainLicenseTextBox";
            MainLicenseTextBox.ReadOnly = true;
            MainLicenseTextBox.ScrollBars = ScrollBars.Both;
            MainLicenseTextBox.Size = new Size(696, 180);
            MainLicenseTextBox.TabIndex = 1;
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 496);
            Controls.Add(MainInfoTabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "INFORMATIONS";
            Text = "InfoForm";
            Load += InfoForm_Load;
            MainInfoTabControl.ResumeLayout(false);
            InfoTabPage.ResumeLayout(false);
            InstructionGroupBox.ResumeLayout(false);
            InstructionGroupBox.PerformLayout();
            InfoGroupBox.ResumeLayout(false);
            InfoGroupBox.PerformLayout();
            LicenseTabPage.ResumeLayout(false);
            OtherLicenseGroupBox.ResumeLayout(false);
            OtherLicenseGroupBox.PerformLayout();
            MainLicenseGroupBox.ResumeLayout(false);
            MainLicenseGroupBox.PerformLayout();
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
        private TextBox InstructionTextBox;
        private TextBox InfoTextBox;
        private TextBox OtherLicenseTextBox;
        private TextBox MainLicenseTextBox;
    }
}