using KombajnPDF.Classes;
using KombajnPDF.Interfaces;
using System.Windows.Forms;

namespace KombajnPDF
{
    public partial class MainForm : Form
    {
        private IFilesBindingList filesBindingList;
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
            {
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    filesBindingList.Add(file);
                }
            }
        }

        private void FilesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var t = e.RowIndex;
        }

        private void RemoveFilesButton_Click(object sender, EventArgs e)
        {

        }
    }
}
