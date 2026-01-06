using KombajnPDF.Classes;
using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Entity;
using KombajnPDF.Interface;
using KombajnPDF.Properties.Translations;
using KombajnPDF.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KombajnPDF.Presenter
{
    /// <summary>
    /// Represents the presenter for the main form in a Model-View-Presenter (MVP) pattern.
    /// Handles user interactions and updates the view accordingly.
    /// </summary>
    class MainFormPresenter
    {
        private readonly IMainFormView mainFormView;
        private readonly FileItemsBindingList files;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainFormPresenter"/> class
        /// and subscribes to events from the view.
        /// </summary>
        /// <param name="mainForm">The main form view.</param>
        public MainFormPresenter(IMainFormView mainForm)
        {
            mainFormView = mainForm;
            files = new FileItemsBindingList();

            mainForm.FilesDataGridViewOnPatternCellEdited += OnPatternCellEdited;
            mainForm.FilesDataGridViewDragEnter += OnFilesDataGridViewDragEnter;
            mainForm.AddFilesButtonOnAddFilesClicked += OnAddFilesButtonClicked;
            mainForm.RemoveFilesButtonClicked += OnRemoveFilesButtonClicked;
            mainForm.MoveUpFilesButtonClicked += OnMoveUpFilesButtonClicked;
            mainForm.MoveDownFilesButtonClicked += OnMoveDownFilesButtonClicked;
            mainForm.CombineFilesButtonClicked += CombineFilesButtonClicked;
            mainForm.SettingsButtonClicked += OpenSettingsFormClicked;
            mainForm.InfoButtonClicked += OpenInfoFormClicked;
        }
        /// <summary>
        /// Opens the info form when the corresponding button is clicked.
        /// </summary>
        private void OpenInfoFormClicked()
        {
            using var form = new InfoForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Opens the settings form when the corresponding button is clicked.
        /// </summary>
        private void OpenSettingsFormClicked()
        {

            using var form = new SettingsForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Combines the selected files and displays a message on success.
        /// </summary>
        public void CombineFilesButtonClicked()
        {
            if (files.Count == 0)
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var combiner = new FilesCombiner();
                combiner.CombineFiles(files.Items);
                mainFormView.ShowMessageBox(GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.COMBINED_FILES), GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.INFORMATION), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                mainFormView.ShowErrorProvider(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Moves selected files one position down in the list.
        /// </summary>
        /// <param name="selectedIndexes">Indexes of selected files.</param>
        private void OnMoveDownFilesButtonClicked(List<int> selectedIndexes)
        {
            if (files.Count <= 1) return;

            List<int> newIndexes = new List<int>();

            foreach (int index in selectedIndexes.OrderByDescending(x => x))
            {
                if (index >= files.Count - 1)
                    continue;

                var file = files[index].FullPath;
                files.RemoveAt(index);
                files.Insert(index + 1, file);
                newIndexes.Add(index + 1);
            }

            mainFormView.RefreshGrid();
            mainFormView.SelectRows(newIndexes);
        }

        /// <summary>
        /// Moves selected files one position up in the list.
        /// </summary>
        /// <param name="selectedIndexes">Indexes of selected files.</param>
        private void OnMoveUpFilesButtonClicked(List<int> selectedIndexes)
        {
            if (files.Count <= 1) return;

            List<int> newIndexes = new List<int>();

            foreach (int index in selectedIndexes.OrderBy(x => x))
            {
                if (index == 0)
                    continue;

                var file = files[index].FullPath;
                files.RemoveAt(index);
                files.Insert(index - 1, file);
                newIndexes.Add(index - 1);
            }

            mainFormView.RefreshGrid();
            mainFormView.SelectRows(newIndexes);
        }

        /// <summary>
        /// Removes selected files from the list.
        /// </summary>
        /// <param name="selectedRows">Selected rows from the DataGridView.</param>
        private void OnRemoveFilesButtonClicked(DataGridViewSelectedRowCollection selectedRows)
        {
            foreach (DataGridViewRow row in selectedRows)
                files.RemoveAt(row.Index);
        }

        /// <summary>
        /// Adds files selected via file dialog to the list.
        /// </summary>
        private void OnAddFilesButtonClicked()
        {
            var files = mainFormView.ShowOpenFileDialog();
            foreach (var path in files)
                this.files.Add(path);
        }

        /// <summary>
        /// Handles drag-and-drop of files into the DataGridView.
        /// </summary>
        /// <param name="e">The drag event arguments.</param>
        private void OnFilesDataGridViewDragEnter(DragEventArgs e)
        {
            if (e.Data is null || !e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                this.files.Add(file);
        }

        /// <summary>
        /// Validates and applies a new pattern to a file when a DataGridView cell is edited.
        /// </summary>
        /// <param name="rowIndex">The index of the edited row.</param>
        /// <param name="columnName">The name of the edited column.</param>
        private void OnPatternCellEdited(int rowIndex, string columnName)
        {
            var file = files[rowIndex];
            if (columnName != nameof(file.FileItemPattern))
                return;

            try
            {
                if (!file.CheckPattern())
                {
                    mainFormView.SetRowStyle(rowIndex, mainFormView.GetErrorStyle());
                    mainFormView.ShowErrorProvider("Wrong pattern for current file!");
                }
                else
                {
                    mainFormView.SetRowStyle(rowIndex, mainFormView.GetCorrectStyle());
                }
            }
            catch (Exception ex)
            {
                mainFormView.SetRowStyle(rowIndex, mainFormView.GetErrorStyle());
                mainFormView.ShowErrorProvider(ex.Message);
            }
        }

        /// <summary>
        /// Returns the current list of files managed by the presenter.
        /// </summary>
        /// <returns>A binding list of files.</returns>
        internal FileItemsBindingList GetBindingList()
        {
            return files;
        }
    }

}
