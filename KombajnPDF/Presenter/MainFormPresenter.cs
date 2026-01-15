using KombajnPDF.Data;
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

            mainForm.SetFilesDataSource(files);
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
        private void CombineFilesButtonClicked()
        {
            if (files.Count == 0)
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var combiner = new FilesCombiner();
                var pathToSave = GetFullPathToCombinedFile();
                combiner.CombineFiles(files.Items, pathToSave);
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
        /// <param name="selectedIndexes">List of selected rows Indexes</param>
        private void OnRemoveFilesButtonClicked(List<int> selectedIndexes)
        {
            foreach (var index in selectedIndexes)
                files.RemoveAt(index);
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
        /// <param name="rowIndex">The index of the edited index.</param>
        /// <param name="columnName">The name of the edited column.</param>
        private void OnPatternCellEdited(int rowIndex, string columnName)
        {
            var file = files[rowIndex];
            if (columnName != nameof(file.FilePattern))
                return;

            try
            {
                var filePatternChecker = new FilePatternChecker();
                if (!filePatternChecker.TryParse(file, out var pages))
                    throw new FormatException("Wrong pattern for current file");
                else
                    mainFormView.SetRowStyle(rowIndex, mainFormView.GetCorrectStyle());
            }
            catch (Exception ex)
            {
                mainFormView.SetRowStyle(rowIndex, mainFormView.GetErrorStyle());
                mainFormView.ShowErrorProvider(ex.Message);
            }
        }

        /// <summary>
        /// Get path to the new file
        /// </summary>
        /// <returns>New full path to the file</returns>
        private string GetFullPathToCombinedFile()
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Files PDF|*.pdf",
                Title = "Save file PDF",
                FileName = "NewDocument.pdf"
            };

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string pathToSave = saveFileDialog.FileName;
                if (string.IsNullOrEmpty(pathToSave))
                {
                    return string.Empty;
                }
                string extension = Path.GetExtension(pathToSave);
                if (string.IsNullOrEmpty(extension))
                {
                    return pathToSave += ".pdf";
                }
                if (extension.Contains(".pdf", StringComparison.CurrentCultureIgnoreCase))
                {
                    return pathToSave;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
