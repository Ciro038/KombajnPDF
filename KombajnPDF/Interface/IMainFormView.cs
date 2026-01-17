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
        event Action<List<int>> RemoveFilesButtonClicked;

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
        /// <summary>
        /// Marks the specified row as valid, indicating that it no longer contains validation errors.  
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the row to mark as valid. Must be within the range of existing rows.</param>
        void MarkRowAsValid(int rowIndex);
        /// <summary>
        /// Marks the specified row as invalid, indicating that it contains errors or does not meet validation criteria.
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the row to mark as invalid. Must be within the range of existing rows.</param>
        void MarkRowAsInvalid(int rowIndex);

        void ShowInfoForm();
        void ShowSettingsForm();
    }

}
