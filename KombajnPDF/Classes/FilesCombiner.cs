using KombajnPDF.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    internal class FilesCombiner
    {
        private string GetPathToTarget()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Files PDF|*.pdf";
            saveFileDialog.Title = "Save file PDF";
            saveFileDialog.FileName = "NewDocument.pdf";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string pathToSave = saveFileDialog.FileName;
                if (String.IsNullOrEmpty(pathToSave))
                {
                    return null;
                }
                string extension = Path.GetExtension(pathToSave);
                if (String.IsNullOrEmpty(extension))
                {
                    return pathToSave += ".pdf";
                }
                if (extension.Contains(".pdf", StringComparison.CurrentCultureIgnoreCase))
                {
                    return pathToSave;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        internal void CombineFiles(List<File> items)
        {
            string fullPath = GetPathToTarget();
            if (String.IsNullOrEmpty(fullPath)) { throw new ArgumentException("First choose where to save the file."); }
            var mainDocument = new PdfDocument();
            foreach (File file in items)
            {
                var currentDocument = PdfReader.Open(file.FullPath, PdfDocumentOpenMode.Import);
                foreach (int pageNumber in file.GetPagesToPrint())
                {
                    mainDocument.AddPage(currentDocument.Pages[pageNumber - 1]);
                }
            }
            mainDocument.Save(fullPath);
            mainDocument.Close();
        }
    }
}