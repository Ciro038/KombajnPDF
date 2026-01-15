using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Interface
{
    /// <summary>
    /// Represents the interface for the main form view in the application.
    /// It defines all UI-related actions and interactions available in the main window.
    /// </summary>
    interface IMainFormView : IBaseFormView
    {
        /// <summary>
        /// Triggered when the pattern cell in the file DataGridView is edited.
        /// </summary>
        event Action<int, string> FilesDataGridViewOnPatternCellEdited;

        /// <summary>
        /// Triggered when files are dragged into the DataGridView area.
        /// </summary>
        event Action<DragEventArgs> FilesDataGridViewDragEnter;

        /// <summary>
        /// Triggered when the user clicks the "Add Files" button.
        /// </summary>
        event Action AddFilesButtonOnAddFilesClicked;

        /// <summary>
        /// Triggered when the user clicks the "Remove Files" button.
        /// </summary>
        event Action<DataGridViewSelectedRowCollection> RemoveFilesButtonClicked;

        /// <summary>
        /// Triggered when the user clicks the "Move Up" button to reorder selected files.
        /// </summary>
        event Action<List<int>> MoveUpFilesButtonClicked;

        /// <summary>
        /// Triggered when the user clicks the "Move Down" button to reorder selected files.
        /// </summary>
        event Action<List<int>> MoveDownFilesButtonClicked;

        /// <summary>
        /// Triggered when the user clicks the "Combine Files" button.
        /// </summary>
        event Action CombineFilesButtonClicked;

        /// <summary>
        /// Triggered when the user clicks to open the settings form.
        /// </summary>
        event Action SettingsButtonClicked;
        /// <summary>
        /// Triggered when the user clicks to open the info form.  
        /// </summary>
        event Action InfoButtonClicked;
        /// <summary>
        /// Returns a cell style used to indicate valid input.
        /// </summary>
        /// <returns>A <see cref="DataGridViewCellStyle"/> representing a valid state.</returns>
        DataGridViewCellStyle GetCorrectStyle();

        /// <summary>
        /// Returns a cell style used to indicate an error or invalid input.
        /// </summary>
        /// <returns>A <see cref="DataGridViewCellStyle"/> representing an error state.</returns>
        DataGridViewCellStyle GetErrorStyle();

        /// <summary>
        /// Opens a file dialog and returns the selected file paths.
        /// </summary>
        /// <returns>An array of file paths selected by the user.</returns>
        string[] ShowOpenFileDialog();

        /// <summary>
        /// Applies the specified style to the given row index.
        /// </summary>
        /// <param name="rowIndex">The index of the row.</param>
        /// <param name="style">The style to apply.</param>
        void SetRowStyle(int rowIndex, DataGridViewCellStyle style);

        /// <summary>
        /// Refreshes the contents of the DataGridView.
        /// </summary>
        void RefreshGrid();

        /// <summary>
        /// Selects rows in the DataGridView based on their indexes.
        /// </summary>
        /// <param name="rowIndexes">A list of row indexes to select.</param>
        void SelectRows(List<int> rowIndexes);

        /// <summary>
        /// Sets the data source for the files displayed in the DataGridView.
        /// </summary>
        /// <param name="dataSource">The data source to set.</param>
        void SetFilesDataSource(object dataSource);
    }

}
