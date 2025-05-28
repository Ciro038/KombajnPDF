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
            label1 = new Label();
            SuspendLayout();
            // 
            // CurrentLanguageComboBox
            // 
            CurrentLanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CurrentLanguageComboBox.FormattingEnabled = true;
            CurrentLanguageComboBox.Location = new Point(12, 35);
            CurrentLanguageComboBox.Name = "CurrentLanguageComboBox";
            CurrentLanguageComboBox.Size = new Size(121, 23);
            CurrentLanguageComboBox.TabIndex = 0;
            CurrentLanguageComboBox.SelectedValueChanged += CurrentLanguageComboBox_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Tag = "language";
            label1.Text = "Language:";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(CurrentLanguageComboBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Tag = "settings";
            Text = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CurrentLanguageComboBox;
        private Label label1;
    }
}