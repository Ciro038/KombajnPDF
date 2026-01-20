using KombajnPDF.App.Data.Abstract;
using KombajnPDF.Data.Entity;
using KombajnPDF.Interface;
using KombajnPDF.Properties.Translations;
using KombajnPDF.View;

namespace KombajnPDF.Presenter
{
    /// <summary>
    /// Represents the presenter for the main form in a Model-View-Presenter (MVP) pattern.
    /// Handles user interactions and updates the view accordingly.
    /// </summary>
    public class MainFormPresenter
    {
        private readonly IMainFormView mainFormView;
        private readonly IFilesCombiner filesCombiner;
        private readonly IFilePatternChecker filePatternChecker;
        private readonly FileItemsBindingList files;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainFormPresenter"/> class
        /// and subscribes to events from the view.
        /// </summary>
        /// <param name="mainForm">The main form view.</param>
        public MainFormPresenter(
            IMainFormView mainForm,
            IFilesCombiner filesCombiner,
            IFilePatternChecker filePatternChecker)
        {
            this.mainFormView = mainForm;
            this.filesCombiner = filesCombiner;
            this.filePatternChecker = filePatternChecker;

            files = new FileItemsBindingList();

            mainForm.FilesDataGridViewOnPatternCellEdited += OnPatternCellEdited;
            mainForm.AddFilesButtonOnAddFilesClicked += OnAddFilesButtonClicked;
            mainForm.RemoveFilesButtonClicked += OnRemoveFilesButtonClicked;
            mainForm.MoveUpFilesButtonClicked += OnMoveUpFilesButtonClicked;
            mainForm.MoveDownFilesButtonClicked += OnMoveDownFilesButtonClicked;
            mainForm.CombineFilesButtonClicked += CombineFilesButtonClicked;
            mainForm.FilesDropped += OnFilesDropped;

            mainForm.SetFilesDataSource(files);
        }

        private void OnFilesDropped(string[] files)
        {
            foreach (var file in files)
                this.files.Add(file);
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
                mainFormView.SetWaitCursor(true);
                var pathToSave = mainFormView.ShowSaveFileDialogForPdfFile();
                filesCombiner.CombineFiles(files.Items, pathToSave);
                mainFormView.ShowMessageBox(GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.COMBINED_FILES), GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.INFORMATION));
            }
            catch (Exception ex)
            {
                mainFormView.ShowError(ex.Message);
            }
            finally
            {
                mainFormView.SetWaitCursor(false);
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
        private void OnPatternCellEdited(int rowIndex)
        {
            try
            {
                var file = files[rowIndex];
                if (!filePatternChecker.TryParse(file, out var pages))
                    throw new FormatException("Wrong pattern for current file");
                else
                    mainFormView.MarkRowAsValid(rowIndex);
            }
            catch (Exception ex)
            {
                mainFormView.MarkRowAsInvalid(rowIndex);
                mainFormView.ShowError(ex.Message);
            }
        }
    }
}
