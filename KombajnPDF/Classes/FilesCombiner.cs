using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Entity;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    /// <summary>
    /// Class is responsible for combining files into one
    /// </summary>
    internal class FilesCombiner
    {
        public static readonly HashSet<string> AllowedExtensions =
            new(new[] { ".jpg", ".jpeg", ".png", ".pdf", ".tiff" },
                StringComparer.OrdinalIgnoreCase);
        /// <summary>
        /// Get path to the new file
        /// </summary>
        /// <returns>New full path to the file</returns>
        private string GetPathToTarget()
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
        /// <summary>
        /// Combine files into new one 
        /// </summary>
        /// <param name="items">Files to combine</param>
        /// <exception cref="ArgumentException">Thrown if no path is selected/exception>
        internal void CombineFiles(List<FileItem> items)
        {
            string fullPath = GetPathToTarget();
            if (string.IsNullOrEmpty(fullPath)) { throw new ArgumentException("First choose where to save the file."); }
            using (var mainDocument = new PdfDocument())
            {
                foreach (FileItem file in items)
                {
                    var currentDocument = PdfReader.Open(file.FullPath, PdfDocumentOpenMode.Import);
                    var filePatternChecker = new FilePatternChecker();
                    if (filePatternChecker.TryParse(file, out var pages))
                    {
                        foreach (int pageNumber in pages)
                        {
                            mainDocument.AddPage(currentDocument.Pages[pageNumber - 1]);
                        }
                    }
                }
                mainDocument.Save(fullPath);
                mainDocument.Close();
            }
        }
    }
}