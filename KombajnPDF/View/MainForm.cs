using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Entity;
using KombajnPDF.Interface;
using KombajnPDF.Presenter;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Windows.Forms;
using File = KombajnPDF.Data.Entity.File;

namespace KombajnPDF
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly MainFormPresenter presenter;
        private DataGridViewCellStyle correctDataGridViewCellStyle;
        private DataGridViewCellStyle errorDataGridViewCellStyle;

        public event Action<int, string> FilesDataGridViewOnPatternCellEdited;
        public event Action<DragEventArgs> FilesDataGridViewDragEnter;
        public event Action AddFilesButtonOnAddFilesClicked;
        public event Action<DataGridViewSelectedRowCollection> RemoveFilesButtonClicked;
        public event Action<List<int>> MoveUpFilesButtonClicked;
        public event Action<List<int>> MoveDownFilesButtonClicked;
        public event Action CombineFilesButtonClicked;
        public event Action OpenSettingsFormClicked;

        public MainForm()
        {
            InitializeComponent();
            presenter = new MainFormPresenter(this);

            InitializeDataGrid();

            GlobalSettingsProvider.Instance.LanguageChanged += () =>
            {
                LanguageService.LocalizeForm(this);
            };

            LanguageService.LocalizeForm(this);

            //SettingsButton.Image = Properties.Resources.Icons.Icons.SettingsIcon.ToBitmap();
            var originalIcon = Properties.Resources.Icons.Icons.SettingsIcon.ToBitmap();
            var resizedIcon = ResizeImage(originalIcon, SettingsButton.ClientSize);
            SettingsButton.Image = resizedIcon;
            SettingsButton.Text = string.Empty;
            SettingsButton.ImageAlign = ContentAlignment.MiddleCenter;
            SettingsButton.FlatStyle = FlatStyle.Flat;
            SettingsButton.FlatAppearance.BorderSize = 0;
            SettingsButton.BackColor = Color.Transparent;
            SettingsButton.TextImageRelation = TextImageRelation.Overlay;
        }
        public static Image ResizeImage(Image image, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, size.Width, size.Height);
            }
            return bmp;
        }
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
            FilesDataGridViewDragEnter(e);
        }
        private void FilesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            FilesDataGridViewOnPatternCellEdited(e.RowIndex, FilesDataGridView.Columns[e.ColumnIndex].Name);
        }
        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            AddFilesButtonOnAddFilesClicked();
        }
        private void RemoveFilesButton_Click(object sender, EventArgs e)
        {
            RemoveFilesButtonClicked(FilesDataGridView.SelectedRows);
        }

        private void MoveUpFilesButton_Click(object sender, EventArgs e)
        {
            var selectedIndexes = FilesDataGridView.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.Index)
                .ToList();

            MoveUpFilesButtonClicked(selectedIndexes);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            var selectedIndexes = FilesDataGridView.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(r => r.Index)
                .ToList();

            MoveDownFilesButtonClicked(selectedIndexes);
        }

        private void CombineFilesButton_Click(object sender, EventArgs e)
        {
            CombineFilesButtonClicked();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            OpenSettingsFormClicked();
        }

        public DataGridViewCellStyle GetCorrectStyle() => correctDataGridViewCellStyle;
        public DataGridViewCellStyle GetErrorStyle() => errorDataGridViewCellStyle;

        public void ShowError(string message)
        {
            MainErrorProvider.SetError(FilesDataGridView, message);
        }

        public void SetRowStyle(int rowIndex, DataGridViewCellStyle style)
        {
            FilesDataGridView.Rows[rowIndex].DefaultCellStyle = style;
        }

        public string[] ShowOpenFileDialog()
        {
            SelectFilesOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return SelectFilesOpenFileDialog.ShowDialog() == DialogResult.OK
                ? SelectFilesOpenFileDialog.FileNames
                : Array.Empty<string>();
        }

        public void RefreshGrid()
        {
            FilesDataGridView.Refresh();
        }

        public void SelectRows(List<int> rowIndexes)
        {
            FilesDataGridView.ClearSelection();
            foreach (int index in rowIndexes)
            {
                if (index >= 0 && index < FilesDataGridView.Rows.Count)
                    FilesDataGridView.Rows[index].Selected = true;
            }
        }
    }
}
