using KombajnPDF.Classes;
using System.Windows.Forms;

namespace KombajnPDF
{
    public partial class MainForm : Form
    {
        private FilesBindingList filesBindingList;
        public MainForm()
        {
            InitializeComponent();
            filesBindingList = new FilesBindingList();
            FilesDataGridView.Columns["NameDataGridViewTextBoxColumn"].DataPropertyName = "FileName";
            FilesDataGridView.Columns["PathDataGridViewTextBoxColumn"].DataPropertyName = "DirectoryPath";
            FilesDataGridView.Columns["PatternDataGridViewTextBoxColumn"].DataPropertyName = "Pattern";
            FilesDataGridView.Columns["TotalPagesDataGridViewTextBoxColumn"].DataPropertyName = "TotalPages";

            FilesDataGridView.DataSource = filesBindingList;
            
            //FilesDataGridView.Columns["FileName"].he
            //FilesDataGridView.Columns["DirectoryPath"]
            //FilesDataGridView.Columns["Pattern"]
            //FilesDataGridView.Columns["TotalPages"]

            //var test = FilesDataGridView.Columns;
            //PathDataGridViewTextBoxColumn.DataPropertyName = "DirectoryPath";
            //PatternDataGridViewTextBoxColumn.DataPropertyName = "Pattern";
            //TotalPagesDataGridViewTextBoxColumn.DataPropertyName = "TotalPages";

            //            private DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn;
            //private DataGridViewTextBoxColumn PathDataGridViewTextBoxColumn;
            //private DataGridViewTextBoxColumn PatternDataGridViewTextBoxColumn;
            //private DataGridViewTextBoxColumn TotalPagesDataGridViewTextBoxColumn;


            //// 
            //// NameDataGridViewTextBoxColumn
            //// 
            //NameDataGridViewTextBoxColumn.HeaderText = "Name";
            //NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn";
            //NameDataGridViewTextBoxColumn.ReadOnly = true;
            //NameDataGridViewTextBoxColumn.Width = 144;
            //// 
            //// PathDataGridViewTextBoxColumn
            //// 
            //PathDataGridViewTextBoxColumn.HeaderText = "Path";
            //PathDataGridViewTextBoxColumn.Name = "PathDataGridViewTextBoxColumn";
            //PathDataGridViewTextBoxColumn.ReadOnly = true;
            //PathDataGridViewTextBoxColumn.Width = 400;
            //// 
            //// PatternDataGridViewTextBoxColumn
            //// 
            //PatternDataGridViewTextBoxColumn.HeaderText = "Pattern";
            //PatternDataGridViewTextBoxColumn.Name = "PatternDataGridViewTextBoxColumn";
            //PatternDataGridViewTextBoxColumn.Width = 150;
            //// 
            //// TotalPagesDataGridViewTextBoxColumn
            //// 
            //TotalPagesDataGridViewTextBoxColumn.HeaderText = "Total pages";
            //TotalPagesDataGridViewTextBoxColumn.Name = "TotalPagesDataGridViewTextBoxColumn";
            //TotalPagesDataGridViewTextBoxColumn.ReadOnly = true;
            //TotalPagesDataGridViewTextBoxColumn.Width = 90;
        }
        private void FilesDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Tutaj mo¿esz obs³u¿yæ przeci¹gniête pliki
                foreach (string file in files)
                {
                    filesBindingList.Add(file);
                }
                //e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
