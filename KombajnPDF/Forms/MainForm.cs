using KombajnPDF.Classes;
using KombajnPDF.Interfaces;
using System.Windows.Forms;
using File = KombajnPDF.Classes.File;

namespace KombajnPDF
{
    public partial class MainForm : Form
    {
        private FilesBindingList filesBindingList;
        public MainForm()
        {
            InitializeComponent();
            filesBindingList = new FilesBindingList();
            FilesDataGridView.Columns["NameDataGridViewTextBoxColumn"].DataPropertyName = "NameDataGridViewTextBoxColumn";
            FilesDataGridView.Columns["PathDataGridViewTextBoxColumn"].DataPropertyName = "PathDataGridViewTextBoxColumn";
            FilesDataGridView.Columns["PatternDataGridViewTextBoxColumn"].DataPropertyName = "PatternDataGridViewTextBoxColumn";
            FilesDataGridView.Columns["TotalPagesDataGridViewTextBoxColumn"].DataPropertyName = "TotalPagesDataGridViewTextBoxColumn";

            FilesDataGridView.DataSource = filesBindingList;
        }
        private void FilesDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data is null)
                return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    filesBindingList.Add(FilesDataGridView.RowCount, file);
                }
            }
        }

        private void FilesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
                return;
            var file = filesBindingList.Where(x => x.RowIndex == e.RowIndex).First();
            var filePatternChecker = new FilePatternChecker();
            if (!file.CheckPattern())
            {
                MainErrorProvider.SetError(FilesDataGridView, "Wrong pattern for current file !");
            }
        }
        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            SelectFilesOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (SelectFilesOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string path in SelectFilesOpenFileDialog.FileNames)
                {
                    filesBindingList.Add(FilesDataGridView.RowCount, path);
                }
            }
        }
        private void RemoveFilesButton_Click(object sender, EventArgs e)
        {

        }


    }
}
