﻿namespace KombajnPDF
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            FilesDataGridView = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
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
            MainErrorProvider = new ErrorProvider(components);
            SelectFilesOpenFileDialog = new OpenFileDialog();
            HelpButton = new Button();
            ((System.ComponentModel.ISupportInitialize)FilesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // FilesDataGridView
            // 
            FilesDataGridView.AllowDrop = true;
            FilesDataGridView.AllowUserToAddRows = false;
            FilesDataGridView.AllowUserToDeleteRows = false;
            FilesDataGridView.AllowUserToResizeRows = false;
            FilesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FilesDataGridView.Columns.AddRange(new DataGridViewColumn[] { Id, NameDataGridViewTextBoxColumn, PathDataGridViewTextBoxColumn, PatternDataGridViewTextBoxColumn, TotalPagesDataGridViewTextBoxColumn });
            FilesDataGridView.Location = new Point(12, 41);
            FilesDataGridView.Name = "FilesDataGridView";
            FilesDataGridView.RowHeadersVisible = false;
            FilesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FilesDataGridView.Size = new Size(787, 242);
            FilesDataGridView.TabIndex = 0;
            FilesDataGridView.CellEndEdit += FilesDataGridView_CellEndEdit;
            FilesDataGridView.DragEnter += FilesDataGridView_DragEnter;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // NameDataGridViewTextBoxColumn
            // 
            NameDataGridViewTextBoxColumn.HeaderText = "Name";
            NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn";
            NameDataGridViewTextBoxColumn.ReadOnly = true;
            NameDataGridViewTextBoxColumn.Width = 144;
            // 
            // PathDataGridViewTextBoxColumn
            // 
            PathDataGridViewTextBoxColumn.HeaderText = "Path";
            PathDataGridViewTextBoxColumn.Name = "PathDataGridViewTextBoxColumn";
            PathDataGridViewTextBoxColumn.ReadOnly = true;
            PathDataGridViewTextBoxColumn.Width = 400;
            // 
            // PatternDataGridViewTextBoxColumn
            // 
            PatternDataGridViewTextBoxColumn.HeaderText = "Pattern";
            PatternDataGridViewTextBoxColumn.Name = "PatternDataGridViewTextBoxColumn";
            PatternDataGridViewTextBoxColumn.Width = 150;
            // 
            // TotalPagesDataGridViewTextBoxColumn
            // 
            TotalPagesDataGridViewTextBoxColumn.HeaderText = "Total pages";
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
            CombineFilesButton.Location = new Point(805, 237);
            CombineFilesButton.Name = "CombineFilesButton";
            CombineFilesButton.Size = new Size(89, 46);
            CombineFilesButton.TabIndex = 6;
            CombineFilesButton.Tag = "COMBINE_FILES";
            CombineFilesButton.Text = "Combine files";
            CombineFilesButton.UseVisualStyleBackColor = true;
            CombineFilesButton.Click += CombineFilesButton_Click;
            // 
            // MainErrorProvider
            // 
            MainErrorProvider.ContainerControl = this;
            // 
            // SelectFilesOpenFileDialog
            // 
            SelectFilesOpenFileDialog.Filter = "Files PDF (*.pdf)|*.pdf";
            SelectFilesOpenFileDialog.Multiselect = true;
            SelectFilesOpenFileDialog.RestoreDirectory = true;
            SelectFilesOpenFileDialog.Title = "Select _files";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 318);
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
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KombajnPDF";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)FilesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)MainErrorProvider).EndInit();
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
        private ErrorProvider MainErrorProvider;
        private OpenFileDialog SelectFilesOpenFileDialog;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn PathDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn PatternDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn TotalPagesDataGridViewTextBoxColumn;
        private Button HelpButton;
    }
}
