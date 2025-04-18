﻿using KombajnPDF.Data.Abstract;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Data.Entity
{
    /// <summary>
    /// Class is responsible for combining _files into one
    /// </summary>
    internal class FilesCombiner
    {
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
        /// Combine _files into new one 
        /// </summary>
        /// <param name="items">Files to combine</param>
        /// <exception cref="ArgumentException">Thrown if no path is selected/exception>
        internal void CombineFiles(List<IFile> items)
        {
            string fullPath = GetPathToTarget();
            if (string.IsNullOrEmpty(fullPath)) { throw new ArgumentException("First choose where to save the file."); }
            var mainDocument = new PdfDocument();
            foreach (IFile file in items)
            {
                var currentDocument = PdfReader.Open(file.GetFullPath(), PdfDocumentOpenMode.Import);
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