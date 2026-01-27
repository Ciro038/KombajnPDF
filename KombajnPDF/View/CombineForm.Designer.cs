namespace KombajnPDF
{
    partial class CombineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombineForm));
            FilesDataGridView = new DataGridView();
            NameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            PathDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            PatternDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            TotalPagesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            SettingsButton = new Button();
            AddFilesButton = new Button();
            MoveUpFilesButton = new Button();
            MoveDownButton = new Button();
            RemoveFilesButton = new Button();
            CombineFilesButton = new Button();
            HelpButton = new Button();
            RemoveAllFilesButton = new Button();
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FilesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // FilesDataGridView
            // 
            FilesDataGridView.AllowDrop = true;
            FilesDataGridView.AllowUserToAddRows = false;
            FilesDataGridView.AllowUserToDeleteRows = false;
            FilesDataGridView.AllowUserToResizeRows = false;
            FilesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FilesDataGridView.Columns.AddRange(new DataGridViewColumn[] { NameDataGridViewTextBoxColumn, PathDataGridViewTextBoxColumn, PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn });
            FilesDataGridView.Location = new Point(12, 41);
            FilesDataGridView.Name = "FilesDataGridView";
            FilesDataGridView.RowHeadersVisible = false;
            FilesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FilesDataGridView.Size = new Size(787, 242);
            FilesDataGridView.TabIndex = 0;
            FilesDataGridView.CellEndEdit += FilesDataGridView_CellEndEdit;
            FilesDataGridView.DragEnter += FilesDataGridView_DragEnter;
            // 
            // NameDataGridViewTextBoxColumn
            // 
            NameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            NameDataGridViewTextBoxColumn.DataPropertyName = "FileNameWithExtension";
            NameDataGridViewTextBoxColumn.HeaderText = "Name";
            NameDataGridViewTextBoxColumn.MinimumWidth = 260;
            NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn";
            NameDataGridViewTextBoxColumn.ReadOnly = true;
            NameDataGridViewTextBoxColumn.Width = 260;
            // 
            // PathDataGridViewTextBoxColumn
            // 
            PathDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            PathDataGridViewTextBoxColumn.DataPropertyName = "PathToFile";
            PathDataGridViewTextBoxColumn.HeaderText = "Path";
            PathDataGridViewTextBoxColumn.MinimumWidth = 280;
            PathDataGridViewTextBoxColumn.Name = "PathDataGridViewTextBoxColumn";
            PathDataGridViewTextBoxColumn.ReadOnly = true;
            PathDataGridViewTextBoxColumn.Width = 280;
            // 
            // PatternDataGridViewTextBoxColumn
            // 
            PatternDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            PatternDataGridViewTextBoxColumn.DataPropertyName = "FilePattern";
            PatternDataGridViewTextBoxColumn.HeaderText = "Pattern";
            PatternDataGridViewTextBoxColumn.MinimumWidth = 70;
            PatternDataGridViewTextBoxColumn.Name = "PatternDataGridViewTextBoxColumn";
            PatternDataGridViewTextBoxColumn.Width = 70;
            // 
            // TotalPagesDataGridViewTextBoxColumn
            // 
            TotalPagesDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            TotalPagesDataGridViewTextBoxColumn.DataPropertyName = "TotalPages";
            TotalPagesDataGridViewTextBoxColumn.HeaderText = "Total pages";
            TotalPagesDataGridViewTextBoxColumn.MinimumWidth = 90;
            TotalPagesDataGridViewTextBoxColumn.Name = "TotalPagesDataGridViewTextBoxColumn";
            TotalPagesDataGridViewTextBoxColumn.ReadOnly = true;
            TotalPagesDataGridViewTextBoxColumn.Width = 90;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(42, 8);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(27, 27);
            SettingsButton.TabIndex = 1;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // AddFilesButton
            // 
            AddFilesButton.Location = new Point(805, 41);
            AddFilesButton.Name = "AddFilesButton";
            AddFilesButton.Size = new Size(74, 33);
            AddFilesButton.TabIndex = 2;
            AddFilesButton.Text = "Add files";
            AddFilesButton.UseVisualStyleBackColor = true;
            AddFilesButton.Click += AddFilesButton_Click;
            // 
            // MoveUpFilesButton
            // 
            MoveUpFilesButton.Location = new Point(805, 94);
            MoveUpFilesButton.Name = "MoveUpFilesButton";
            MoveUpFilesButton.Size = new Size(74, 33);
            MoveUpFilesButton.TabIndex = 3;
            MoveUpFilesButton.Text = "Move up";
            MoveUpFilesButton.UseVisualStyleBackColor = true;
            MoveUpFilesButton.Click += MoveUpFilesButton_Click;
            // 
            // MoveDownButton
            // 
            MoveDownButton.Location = new Point(805, 139);
            MoveDownButton.Name = "MoveDownButton";
            MoveDownButton.Size = new Size(74, 33);
            MoveDownButton.TabIndex = 4;
            MoveDownButton.Text = "Move down";
            MoveDownButton.UseVisualStyleBackColor = true;
            MoveDownButton.Click += MoveDownButton_Click;
            // 
            // RemoveFilesButton
            // 
            RemoveFilesButton.Location = new Point(805, 185);
            RemoveFilesButton.Name = "RemoveFilesButton";
            RemoveFilesButton.Size = new Size(74, 33);
            RemoveFilesButton.TabIndex = 5;
            RemoveFilesButton.Text = "Ramove files";
            RemoveFilesButton.UseVisualStyleBackColor = true;
            RemoveFilesButton.Click += RemoveFilesButton_Click;
            // 
            // CombineFilesButton
            // 
            CombineFilesButton.Location = new Point(1038, 87);
            CombineFilesButton.Name = "CombineFilesButton";
            CombineFilesButton.Size = new Size(89, 46);
            CombineFilesButton.TabIndex = 6;
            CombineFilesButton.Tag = "COMBINE_FILES";
            CombineFilesButton.Text = "Combine files";
            CombineFilesButton.UseVisualStyleBackColor = true;
            CombineFilesButton.Click += CombineFilesButton_Click;
            // 
            // HelpButton
            // 
            HelpButton.Location = new Point(12, 9);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(24, 24);
            HelpButton.TabIndex = 7;
            HelpButton.Text = "Info";
            HelpButton.UseVisualStyleBackColor = true;
            HelpButton.Click += HelpButton_Click;
            // 
            // RemoveAllFilesButton
            // 
            RemoveAllFilesButton.Location = new Point(805, 239);
            RemoveAllFilesButton.Name = "RemoveAllFilesButton";
            RemoveAllFilesButton.Size = new Size(74, 33);
            RemoveAllFilesButton.TabIndex = 8;
            RemoveAllFilesButton.Text = "Remove all files";
            RemoveAllFilesButton.UseVisualStyleBackColor = true;
            RemoveAllFilesButton.Click += RemoveAllFilesButton_Click;
            // 
            // CombineForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1495, 448);
            Controls.Add(RemoveAllFilesButton);
            Controls.Add(HelpButton);
            Controls.Add(CombineFilesButton);
            Controls.Add(RemoveFilesButton);
            Controls.Add(MoveDownButton);
            Controls.Add(MoveUpFilesButton);
            Controls.Add(AddFilesButton);
            Controls.Add(SettingsButton);
            Controls.Add(FilesDataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CombineForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KombajnPDF";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).EndInit();
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
        private Button HelpButton;
        private DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn PathDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn PatternDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn TotalPagesDataGridViewTextBoxColumn;
        private Button RemoveAllFilesButton;
    }
}
