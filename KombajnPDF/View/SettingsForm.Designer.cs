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
            CurrentLanguageComboBox = new ComboBox();
            SuspendLayout();
            // 
            // CurrentLanguageComboBox
            // 
            CurrentLanguageComboBox.FormattingEnabled = true;
            CurrentLanguageComboBox.Location = new Point(12, 12);
            CurrentLanguageComboBox.Name = "CurrentLanguageComboBox";
            CurrentLanguageComboBox.Size = new Size(121, 23);
            CurrentLanguageComboBox.TabIndex = 0;
            CurrentLanguageComboBox.SelectedValueChanged += CurrentLanguageComboBox_SelectedValueChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CurrentLanguageComboBox);
            Name = "SettingsForm";
            Text = "SettingsForm";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CurrentLanguageComboBox;
    }
}