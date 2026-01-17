using KombajnPDF.App.Data.Abstract;
using KombajnPDF.Classes.Form;
using KombajnPDF.Data.Entity;
using KombajnPDF.Interface;
using KombajnPDF.Presenter;
using KombajnPDF.View;
using KombajnPDF.App.Data.Entity;
namespace KombajnPDF;

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
    public event Action<List<int>> RemoveFilesButtonClicked;
    /// <inheritdoc/>
    public event Action<List<int>> MoveUpFilesButtonClicked;
    /// <inheritdoc/>
    public event Action<List<int>> MoveDownFilesButtonClicked;
    /// <inheritdoc/>
    public event Action CombineFilesButtonClicked;

    /// <summary>
    /// Initializes the main form and its components.
    /// </summary>
    public MainForm()
    {
        InitializeComponent();

        // infrastruktura
        IFilePatternChecker patternChecker = new FilePatternChecker();
        IImageToPdfConverter imageConverter = new PdfSharpImageToPdfConverter();
        IPdfLoader pdfLoader = new PdfSharpLoader();

        // serwis domenowy
        IFilesCombiner filesCombiner = new FilesCombiner(
            patternChecker,
            imageConverter,
            pdfLoader);

        presenter = new MainFormPresenter(
            this,
            filesCombiner,
            patternChecker);

        InitializeDataGrid();
    }

    /// <summary>
    /// Initializes the file data grid view, binds it to the file list, and sets up styles.
    /// </summary>
    private void InitializeDataGrid()
    {
        FilesDataGridView.AutoGenerateColumns = false;
        FilesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        FilesDataGridView.Columns["NameDataGridViewTextBoxColumn"].Tag = "FILE_NAME";
        FilesDataGridView.Columns["PathDataGridViewTextBoxColumn"].Tag = "PATH_TO_FILE";
        FilesDataGridView.Columns["PatternDataGridViewTextBoxColumn"].Tag = "PATTERN";
        FilesDataGridView.Columns["TotalPagesDataGridViewTextBoxColumn"].Tag = "TOTAL_PAGES";

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
        var selectedIndexes = FilesDataGridView.SelectedRows
            .Cast<DataGridViewRow>()
            .Select(r => r.Index)
            .ToList();
        RemoveFilesButtonClicked?.Invoke(selectedIndexes);
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
        ShowSettingsForm();
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
        ShowInfoForm();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

        IconsProvider.SetIconWithResize(SettingsButton, App.Properties.Resources.Icons.Icons.SettingsIcon);
        IconsProvider.SetIconWithResize(MoveUpFilesButton, App.Properties.Resources.Icons.Icons.UpIcon);
        IconsProvider.SetIconWithResize(MoveDownButton, App.Properties.Resources.Icons.Icons.DownIcon);
        IconsProvider.SetIconWithResize(RemoveFilesButton, App.Properties.Resources.Icons.Icons.DeleteIcon);
        IconsProvider.SetIconWithResize(AddFilesButton, App.Properties.Resources.Icons.Icons.AddIcon);
        IconsProvider.SetIconWithResize(HelpButton, App.Properties.Resources.Icons.Icons.HelpIcon);
    }

    public override void ShowErrorProvider(string message)
    {
        base.ShowErrorProvider(FilesDataGridView, message);
    }

    public void SetFilesDataSource(object dataSource)
    {
        FilesDataGridView.DataSource = dataSource;
    }

    public void MarkRowAsValid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= FilesDataGridView.Rows.Count)
            return;

        FilesDataGridView.Rows[rowIndex].DefaultCellStyle = correctDataGridViewCellStyle;
    }

    public void MarkRowAsInvalid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= FilesDataGridView.Rows.Count)
            return;

        FilesDataGridView.Rows[rowIndex].DefaultCellStyle = errorDataGridViewCellStyle;
    }

    public void ShowInfoForm()
    {
        using var form = new InfoForm();
        form.ShowDialog();
    }

    public void ShowSettingsForm()
    {
        using var form = new SettingsForm();
        form.ShowDialog();
    }
}
