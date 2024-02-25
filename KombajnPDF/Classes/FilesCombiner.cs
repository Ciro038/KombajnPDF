﻿using KombajnPDF.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
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
                if (String.IsNullOrEmpty(pathToSave))
                {
                    return String.Empty;
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
                    return String.Empty;
                }
            }
            else
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// Combine files into new one 
        /// </summary>
        /// <param name="items">Files to combine</param>
        /// <exception cref="ArgumentException">Thrown if no path is selected/exception>
        internal void CombineFiles(List<IFile> items)
        {
            string fullPath = GetPathToTarget();
            if (String.IsNullOrEmpty(fullPath)) { throw new ArgumentException("First choose where to save the file."); }
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