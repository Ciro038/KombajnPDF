using KombajnPDF.Classes;
using KombajnPDF.Interfaces;
using System.Windows.Forms;
using File = KombajnPDF.Classes.File;

namespace KombajnPDF
{
    public partial class MainForm : Form
    {
        private IFilesBindingList filesBindingList;
        public MainForm()
        {
            InitializeComponent();
            filesBindingList = new FilesBindingList();
            //FilesDataGridView.Columns["Id"].DataPropertyName = "Id";
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
                    filesBindingList.Add(file);
                }
            }
        }

        private void FilesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
                return;
            var file = filesBindingList[e.RowIndex];
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
                    filesBindingList.Add(path);
                }
            }
        }
        private void RemoveFilesButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in FilesDataGridView.SelectedRows)
            {
                filesBindingList.RemoveAt(row.Index);
            }
        }

        private void MoveUpFilesButton_Click(object sender, EventArgs e)
        {
            if (FilesDataGridView.Rows.Count == 1)
            {
                return;
            }
            List<int> newIndexes = new List<int>();
            foreach (DataGridViewRow item in FilesDataGridView.SelectedRows)
            {
                if (item.Index == 0)
                {
                    continue;
                }
                var copiedRow = filesBindingList[item.Index];
                int newIndex = item.Index - 1;
                filesBindingList.RemoveAt(item.Index);
                filesBindingList.Insert(newIndex, copiedRow);
                newIndexes.Add(newIndex);
            }
            FilesDataGridView.ClearSelection();
            foreach (int newIndex in newIndexes.OrderByDescending(x=>x))
            {
                FilesDataGridView.Rows[newIndex].Selected = true;
            }
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (FilesDataGridView.Rows.Count == 1)
            {
                return;
            }
            List<int> newIndexes = new List<int>();
            foreach (DataGridViewRow item in FilesDataGridView.SelectedRows)
            {
                if (item.Index == FilesDataGridView.Rows.Count-1)
                {
                    continue;
                }
                FilesDataGridView.Rows[item.Index].Selected = false;
                var copiedRow = filesBindingList[item.Index];
                int newIndex = item.Index + 1;
                filesBindingList.RemoveAt(item.Index);
                filesBindingList.Insert(newIndex, copiedRow);
                newIndexes.Add(newIndex);
            }
            FilesDataGridView.ClearSelection();
            foreach (int newIndex in newIndexes.OrderBy(x => x))
            {
                FilesDataGridView.Rows[newIndex].Selected = true;
            }
        }
    }
}
