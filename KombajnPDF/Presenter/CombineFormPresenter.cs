using KombajnPDF.App.Interface;
using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Entity;
using KombajnPDF.Data.Translations;
using KombajnPDF.View;

namespace KombajnPDF.App.Presenter
{
    /// <summary>
    /// Represents the presenter for the main formView in a Model-View-Presenter (MVP) pattern.
    /// Handles user interactions and updates the view accordingly.
    /// </summary>
    public class CombineFormPresenter
    {
        private readonly ICombineFormView formView;
        private readonly IFilesCombiner filesCombiner;
        private readonly IFilePatternChecker filePatternChecker;
        private readonly FileItemsBindingList files;

        /// <summary>
        /// Initializes a new instance of the <see cref="CombineFormPresenter"/> class
        /// and subscribes to events from the view.
        /// </summary>
        /// <param name="formView">The main formView view.</param>
        public CombineFormPresenter(
            ICombineFormView formView,
            IFilesCombiner filesCombiner,
            IFilePatternChecker filePatternChecker)
        {
            this.formView = formView;
            this.filesCombiner = filesCombiner;
            this.filePatternChecker = filePatternChecker;

            files = new FileItemsBindingList();

            formView.FilesDataGridViewOnPatternCellEdited += OnPatternCellEdited;
            formView.AddFilesButtonOnAddFilesClicked += OnAddFilesButtonClicked;
            formView.RemoveFilesButtonClicked += OnRemoveFilesButtonClicked;
            formView.MoveUpFilesButtonClicked += OnMoveUpFilesButtonClicked;
            formView.MoveDownFilesButtonClicked += OnMoveDownFilesButtonClicked;
            formView.CombineFilesButtonClicked += CombineFilesButtonClicked;
            formView.FilesDropped += OnFilesDropped;

            formView.SetFilesDataSource(files);
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
                formView.SetWaitCursor(true);
                var pathToSave = formView.ShowSaveFileDialogForPdfFile();
                filesCombiner.CombineFiles(files.Items, pathToSave);
                formView.ShowMessageBox(GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.COMBINED_FILES), GlobalSettingsProvider.Instance.TranslateCode(TranslationCodes.INFORMATION));
            }
            catch (Exception ex)
            {
                formView.ShowError(ex.Message);
            }
            finally
            {
                formView.SetWaitCursor(false);
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

            formView.RefreshGrid();
            formView.SelectRows(newIndexes);
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

            formView.RefreshGrid();
            formView.SelectRows(newIndexes);
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
            var files = formView.ShowOpenFileDialog();
            foreach (var path in files)
                this.files.Add(path);
        }

        /// <summary>
        /// Validates and applies a new pattern to a file when a DataGridView cell is edited.
        /// </summary>
        /// <param name="rowIndex">The index of the edited index.</param>
        private void OnPatternCellEdited(int rowIndex)
        {
            try
            {
                var file = files[rowIndex];
                if (!filePatternChecker.TryParse(file, out var pages))
                    throw new FormatException($"Invalid pattern for file: {file.FileNameWithExtension}");
                else
                    formView.MarkRowAsValid(rowIndex);
            }
            catch (Exception ex)
            {
                formView.MarkRowAsInvalid(rowIndex);
                formView.ShowError(ex.Message);
            }
        }
    }
}
