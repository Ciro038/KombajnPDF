using KombajnPDF.Classes;
using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Entity;
using KombajnPDF.Interface;
using KombajnPDF.Properties.Translations;
using KombajnPDF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KombajnPDF.Presenter
{
    class MainFormPresenter
    {
        private readonly IMainFormView _view;
        private readonly FilesBindingList _files;

        public MainFormPresenter(IMainFormView mainForm)
        {
            _view = mainForm;
            _files = new FilesBindingList();

            mainForm.FilesDataGridViewOnPatternCellEdited += OnPatternCellEdited;
            mainForm.FilesDataGridViewDragEnter += OnFilesDataGridViewDragEnter;
            mainForm.AddFilesButtonOnAddFilesClicked += OnAddFilesButtonClicked;
            mainForm.RemoveFilesButtonClicked += OnRemoveFilesButtonClicked;
            mainForm.MoveUpFilesButtonClicked += OnMoveUpFilesButtonClicked;
            mainForm.MoveDownFilesButtonClicked += OnMoveDownFilesButtonClicked;
            mainForm.CombineFilesButtonClicked += CombineFilesButtonClicked;
            mainForm.OpenSettingsFormClicked += OpenSettingsFormClicked;
        }

        private void OpenSettingsFormClicked()
        {
            var form = new SettingsForm();
            form.ShowDialog();
        }

        public void CombineFilesButtonClicked()
        {
            if (_files.Count == 0)
                return;

            try
            {
                var combiner = new FilesCombiner();
                combiner.CombineFiles(_files.Items);
                MessageBox.Show(GlobalSettingsProvider.Instance.Translate(TranslationCodes.COMBINED_FILES));
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
        private void OnMoveDownFilesButtonClicked(List<int> selectedIndexes)
        {
            if (_files.Count <= 1) return;

            List<int> newIndexes = new List<int>();

            foreach (int index in selectedIndexes.OrderByDescending(x => x))
            {
                if (index >= _files.Count - 1)
                    continue;

                var file = _files[index].GetFullPath();
                _files.RemoveAt(index);
                _files.Insert(index + 1, file);
                newIndexes.Add(index + 1);
            }

            _view.RefreshGrid();
            _view.SelectRows(newIndexes);
        }

        private void OnMoveUpFilesButtonClicked(List<int> selectedIndexes)
        {
            if (_files.Count <= 1) return;

            List<int> newIndexes = new List<int>();

            foreach (int index in selectedIndexes.OrderBy(x => x))
            {
                if (index == 0)
                    continue;

                var file = _files[index].GetFullPath();
                _files.RemoveAt(index);
                _files.Insert(index - 1, file);
                newIndexes.Add(index - 1);
            }

            _view.RefreshGrid();
            _view.SelectRows(newIndexes);
            //if (FilesDataGridView.Rows.Count == 1)
            //{
            //    return;
            //}
            //List<int> newIndexes = new List<int>();
            //foreach (DataGridViewRow item in FilesDataGridView.SelectedRows)
            //{
            //    if (item.Index == 0)
            //    {
            //        continue;
            //    }
            //    string fullPathToFile = filesBindingList[item.Index].GetFullPath();
            //    int newIndex = item.Index - 1;
            //    filesBindingList.RemoveAt(item.Index);
            //    filesBindingList.Insert(newIndex, fullPathToFile);
            //    newIndexes.Add(newIndex);
            //}
            //FilesDataGridView.ClearSelection();
            //foreach (int newIndex in newIndexes.OrderByDescending(x => x))
            //{
            //    FilesDataGridView.Rows[newIndex].Selected = true;
            //}
        }

        private void OnRemoveFilesButtonClicked(DataGridViewSelectedRowCollection selectedRows)
        {
            foreach (DataGridViewRow row in selectedRows)
                _files.RemoveAt(row.Index);
        }

        private void OnAddFilesButtonClicked()
        {
            var files = _view.ShowOpenFileDialog();
            foreach (var path in files)
                _files.Add(path);
        }

        private void OnFilesDataGridViewDragEnter(DragEventArgs e)
        {
            if (e.Data is null || !e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                _files.Add(file);
        }

        private void OnPatternCellEdited(int rowIndex, string columnName)
        {
            var file = _files[rowIndex];
            if (columnName != nameof(file.PatternDataGridViewTextBoxColumn))
                return;

            try
            {
                if (!file.CheckPattern())
                {
                    _view.SetRowStyle(rowIndex, _view.GetErrorStyle());
                    _view.ShowError("Wrong pattern for current file!");
                }
                else
                {
                    _view.SetRowStyle(rowIndex, _view.GetCorrectStyle());
                }
            }
            catch (Exception ex)
            {
                _view.SetRowStyle(rowIndex, _view.GetErrorStyle());
                _view.ShowError(ex.Message);
            }
        }

        internal FilesBindingList GetBindingList()
        {
            return _files;
        }
    }
}
