namespace KombajnPDF.View
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            CurrentLanguageComboBox = new ComboBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // CurrentLanguageComboBox
            // 
            CurrentLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CurrentLanguageComboBox.FormattingEnabled = true;
            CurrentLanguageComboBox.Location = new Point(6, 22);
            CurrentLanguageComboBox.Name = "CurrentLanguageComboBox";
            CurrentLanguageComboBox.Size = new Size(121, 23);
            CurrentLanguageComboBox.TabIndex = 0;
            CurrentLanguageComboBox.SelectedValueChanged += CurrentLanguageComboBox_SelectedValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CurrentLanguageComboBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(139, 57);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Tag = "LANGUAGE";
            groupBox1.Text = "Language";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 381);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Tag = "SETTINGS";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CurrentLanguageComboBox;
        private GroupBox groupBox1;
    }
}