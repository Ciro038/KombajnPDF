using KombajnPDF.Classes;
using KombajnPDF.Classes.Form;
using KombajnPDF.Interface;
using KombajnPDF.Presenter;

namespace KombajnPDF
{
    /// <summary>
    /// Main form of the application that handles user interface logic for PDF combining.
    /// Implements <see cref="IMainFormView"/> to communicate with the presenter.
    /// </summary>
    public partial class MainForm : BaseForm, IMainFormView
    {
        private readonly MainFormPresenter presenter;
        private DataGridViewCellStyle correctDataGridViewCellStyle;
        private DataGridViewCellStyle errorDataGridViewCellStyle;

        /// <inheritdoc/>
        public event Action<int, string> FilesDataGridViewOnPatternCellEdited;
        /// <inheritdoc/>
        public event Action<DragEventArgs> FilesDataGridViewDragEnter;
        /// <inheritdoc/>
        public event Action AddFilesButtonOnAddFilesClicked;
        /// <inheritdoc/>
        public event Action<DataGridViewSelectedRowCollection> RemoveFilesButtonClicked;
        /// <inheritdoc/>
        public event Action<List<int>> MoveUpFilesButtonClicked;
        /// <inheritdoc/>
        public event Action<List<int>> MoveDownFilesButtonClicked;
        /// <inheritdoc/>
        public event Action CombineFilesButtonClicked;
        /// <inheritdoc/>
        public event Action SettingsButtonClicked;
        /// <inheritdoc/>
        public event Action InfoButtonClicked;

        /// <summary>
        /// Initializes the main form and its components.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            presenter = new MainFormPresenter(this);
        }

        /// <summary>
        /// Initializes the file data grid view, binds it to the file list, and sets up styles.
        /// </summary>
        private void InitializeDataGrid()
        {
            FilesDataGridView.AutoGenerateColumns = false;
            FilesDataGridView.DataSource = presenter.GetBindingList();

            FilesDataGridView.Columns["NameDataGridViewTextBoxColumn"].DataPropertyName = "NameDataGridViewTextBoxColumn";
            FilesDataGridView.Columns["PathDataGridViewTextBoxColumn"].DataPropertyName = "PathDataGridViewTextBoxColumn";
            FilesDataGridView.Columns["PatternDataGridViewTextBoxColumn"].DataPropertyName = "PatternDataGridViewTextBoxColumn";
            FilesDataGridView.Columns["TotalPagesDataGridViewTextBoxColumn"].DataPropertyName = "TotalPagesDataGridViewTextBoxColumn";

            correctDataGridViewCellStyle = FilesDataGridView.DefaultCellStyle;
            errorDataGridViewCellStyle = correctDataGridViewCellStyle.Clone();
            errorDataGridViewCellStyle.BackColor = Color.Red;
        }

        private void FilesDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            FilesDataGridViewDragEnter?.Invoke(e);
        }

        private void FilesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            FilesDataGridViewOnPatternCellEdited?.Invoke(e.RowIndex, FilesDataGridView.Columns[e.ColumnIndex].Name);
        }

        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            AddFilesButtonOnAddFilesClicked?.Invoke();
        }

        private void RemoveFilesButton_Click(object sender, EventArgs e)
        {
            RemoveFilesButtonClicked?.Invoke(FilesDataGridView.SelectedRows);
        }

        private void MoveUpFilesButton_Click(object sender, EventArgs e)
        {
            var selectedIndexes = FilesDataGridView.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.Index)
                .ToList();

            MoveUpFilesButtonClicked?.Invoke(selectedIndexes);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            var selectedIndexes = FilesDataGridView.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.Index)
                .ToList();

            MoveDownFilesButtonClicked?.Invoke(selectedIndexes);
        }

        private void CombineFilesButton_Click(object sender, EventArgs e)
        {
            CombineFilesButtonClicked?.Invoke();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsButtonClicked?.Invoke();
        }

        /// <inheritdoc/>
        public DataGridViewCellStyle GetCorrectStyle() => correctDataGridViewCellStyle;

        /// <inheritdoc/>
        public DataGridViewCellStyle GetErrorStyle() => errorDataGridViewCellStyle;

        /// <inheritdoc/>
        public void SetRowStyle(int rowIndex, DataGridViewCellStyle style)
        {
            FilesDataGridView.Rows[rowIndex].DefaultCellStyle = style;
        }

        /// <inheritdoc/>
        public string[] ShowOpenFileDialog()
        {
            SelectFilesOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return SelectFilesOpenFileDialog.ShowDialog() == DialogResult.OK
                ? SelectFilesOpenFileDialog.FileNames
                : Array.Empty<string>();
        }

        /// <inheritdoc/>
        public void RefreshGrid()
        {
            FilesDataGridView.Refresh();
        }

        /// <inheritdoc/>
        public void SelectRows(List<int> rowIndexes)
        {
            FilesDataGridView.ClearSelection();
            foreach (int index in rowIndexes)
            {
                if (index >= 0 && index < FilesDataGridView.Rows.Count)
                    FilesDataGridView.Rows[index].Selected = true;
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            InfoButtonClicked?.Invoke();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IconsProvider.SetIconWithResize(SettingsButton, Properties.Resources.Icons.Icons.SettingsIcon);
            IconsProvider.SetIconWithResize(MoveUpFilesButton, Properties.Resources.Icons.Icons.UpIcon);
            IconsProvider.SetIconWithResize(MoveDownButton, Properties.Resources.Icons.Icons.DownIcon);
            IconsProvider.SetIconWithResize(RemoveFilesButton, Properties.Resources.Icons.Icons.DeleteIcon);
            IconsProvider.SetIconWithResize(AddFilesButton, Properties.Resources.Icons.Icons.AddIcon);
            IconsProvider.SetIconWithResize(HelpButton, Properties.Resources.Icons.Icons.HelpIcon);

            InitializeDataGrid();
        }

        public override void ShowErrorProvider(string message)
        {
            base.ShowErrorProvider(FilesDataGridView, message);
        }
    }
}
