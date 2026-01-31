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
            OptionsGroupBox = new GroupBox();
            OpenFileAfterCombineCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).BeginInit();
            groupBox1.SuspendLayout();
            OptionsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CurrentLanguageComboBox
            // 
            CurrentLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CurrentLanguageComboBox.FormattingEnabled = true;
            CurrentLanguageComboBox.Location = new Point(6, 22);
            CurrentLanguageComboBox.Name = "CurrentLanguageComboBox";
            CurrentLanguageComboBox.Size = new Size(184, 23);
            CurrentLanguageComboBox.TabIndex = 0;
            CurrentLanguageComboBox.SelectedValueChanged += CurrentLanguageComboBox_SelectedValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CurrentLanguageComboBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(198, 57);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Tag = "LANGUAGE";
            groupBox1.Text = "Language";
            // 
            // OptionsGroupBox
            // 
            OptionsGroupBox.Controls.Add(OpenFileAfterCombineCheckBox);
            OptionsGroupBox.Location = new Point(12, 91);
            OptionsGroupBox.Name = "OptionsGroupBox";
            OptionsGroupBox.Size = new Size(198, 53);
            OptionsGroupBox.TabIndex = 3;
            OptionsGroupBox.TabStop = false;
            OptionsGroupBox.Tag = "OPTIONS";
            OptionsGroupBox.Text = "Options";
            // 
            // OpenFileAfterCombineCheckBox
            // 
            OpenFileAfterCombineCheckBox.AutoSize = true;
            OpenFileAfterCombineCheckBox.Location = new Point(6, 22);
            OpenFileAfterCombineCheckBox.Name = "OpenFileAfterCombineCheckBox";
            OpenFileAfterCombineCheckBox.Size = new Size(148, 19);
            OpenFileAfterCombineCheckBox.TabIndex = 0;
            OpenFileAfterCombineCheckBox.Tag = "OPEN_FILE_AFTER_COMBINE";
            OpenFileAfterCombineCheckBox.Text = "OpenFileAfterCombine";
            OpenFileAfterCombineCheckBox.UseVisualStyleBackColor = true;
            OpenFileAfterCombineCheckBox.CheckedChanged += OpenFileAfterCombineCheckBox_CheckedChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 381);
            Controls.Add(OptionsGroupBox);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Tag = "SETTINGS";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            OptionsGroupBox.ResumeLayout(false);
            OptionsGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CurrentLanguageComboBox;
        private GroupBox groupBox1;
        private GroupBox OptionsGroupBox;
        private CheckBox OpenFileAfterCombineCheckBox;
    }
}