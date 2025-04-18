using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interface
{
    interface IMainFormView
    {
        event Action<int, string> FilesDataGridViewOnPatternCellEdited;
        event Action<DragEventArgs> FilesDataGridViewDragEnter;
        event Action AddFilesButtonOnAddFilesClicked;
        event Action<DataGridViewSelectedRowCollection> RemoveFilesButtonClicked;
        event Action<List<int>> MoveUpFilesButtonClicked;
        event Action<List<int>> MoveDownFilesButtonClicked;
        event Action CombineFilesButtonClicked;
        event Action OpenSettingsFormClicked;
        DataGridViewCellStyle GetCorrectStyle();
        DataGridViewCellStyle GetErrorStyle();
        string[] ShowOpenFileDialog();
        void ShowError(string message);
        void SetRowStyle(int rowIndex, DataGridViewCellStyle style);
        void RefreshGrid();
        void SelectRows(List<int> rowIndexes);
    }
}
