namespace KombajnPDF
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FilesDataGridView = new DataGridView();
            SettingsButton = new Button();
            AddFilesButton = new Button();
            MoveUpFilesButton = new Button();
            MoveDownButton = new Button();
            RemoveFilesButton = new Button();
            CombineFilesButton = new Button();
            Name = new DataGridViewTextBoxColumn();
            Path = new DataGridViewTextBoxColumn();
            Pattern = new DataGridViewTextBoxColumn();
            TotalPages = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)FilesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // FilesDataGridView
            // 
            FilesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FilesDataGridView.Columns.AddRange(new DataGridViewColumn[] { Name, Path, Pattern, TotalPages });
            FilesDataGridView.Location = new Point(12, 41);
            FilesDataGridView.Name = "FilesDataGridView";
            FilesDataGridView.Size = new Size(787, 242);
            FilesDataGridView.TabIndex = 0;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(843, 1);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(75, 23);
            SettingsButton.TabIndex = 1;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            // 
            // AddFilesButton
            // 
            AddFilesButton.Location = new Point(813, 41);
            AddFilesButton.Name = "AddFilesButton";
            AddFilesButton.Size = new Size(99, 23);
            AddFilesButton.TabIndex = 2;
            AddFilesButton.Text = "Add files";
            AddFilesButton.UseVisualStyleBackColor = true;
            // 
            // MoveUpFilesButton
            // 
            MoveUpFilesButton.Location = new Point(813, 78);
            MoveUpFilesButton.Name = "MoveUpFilesButton";
            MoveUpFilesButton.Size = new Size(99, 23);
            MoveUpFilesButton.TabIndex = 3;
            MoveUpFilesButton.Text = "Move up";
            MoveUpFilesButton.UseVisualStyleBackColor = true;
            // 
            // MoveDownButton
            // 
            MoveDownButton.Location = new Point(813, 115);
            MoveDownButton.Name = "MoveDownButton";
            MoveDownButton.Size = new Size(99, 23);
            MoveDownButton.TabIndex = 4;
            MoveDownButton.Text = "Move down";
            MoveDownButton.UseVisualStyleBackColor = true;
            // 
            // RemoveFilesButton
            // 
            RemoveFilesButton.Location = new Point(813, 152);
            RemoveFilesButton.Name = "RemoveFilesButton";
            RemoveFilesButton.Size = new Size(99, 23);
            RemoveFilesButton.TabIndex = 5;
            RemoveFilesButton.Text = "Ramove files";
            RemoveFilesButton.UseVisualStyleBackColor = true;
            // 
            // CombineFilesButton
            // 
            CombineFilesButton.Location = new Point(809, 237);
            CombineFilesButton.Name = "CombineFilesButton";
            CombineFilesButton.Size = new Size(103, 46);
            CombineFilesButton.TabIndex = 6;
            CombineFilesButton.Text = "Combine files";
            CombineFilesButton.UseVisualStyleBackColor = true;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // Path
            // 
            Path.HeaderText = "Path";
            Path.Name = "Path";
            Path.ReadOnly = true;
            Path.Width = 200;
            // 
            // Pattern
            // 
            Pattern.HeaderText = "Pattern";
            Pattern.Name = "Pattern";
            // 
            // TotalPages
            // 
            TotalPages.HeaderText = "Total pages";
            TotalPages.Name = "TotalPages";
            TotalPages.ReadOnly = true;
            TotalPages.Width = 90;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 318);
            Controls.Add(CombineFilesButton);
            Controls.Add(RemoveFilesButton);
            Controls.Add(MoveDownButton);
            Controls.Add(MoveUpFilesButton);
            Controls.Add(AddFilesButton);
            Controls.Add(SettingsButton);
            Controls.Add(FilesDataGridView);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KombajnPDF";
            ((System.ComponentModel.ISupportInitialize)FilesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView FilesDataGridView;
        private Button SettingsButton;
        private Button AddFilesButton;
        private Button MoveUpFilesButton;
        private Button MoveDownButton;
        private Button RemoveFilesButton;
        private Button CombineFilesButton;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Path;
        private DataGridViewTextBoxColumn Pattern;
        private DataGridViewTextBoxColumn TotalPages;
    }
}
