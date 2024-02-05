using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{

    internal class File
    {
        [Browsable(false)]
        private string fullPath { get; set; }

        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(true)]
        [DisplayName("Name")]
        public string FileName { get; set; }

        [Browsable(true)]
        [DisplayName("Path")]
        public string DirectoryPath { get; set; }

        [Browsable(true)]
        [DisplayName("Pattern")]
        public string Pattern { get; set; }

        [Browsable(true)]
        [DisplayName("Total pages")]
        public int TotalPages { get; set; }

        private static int newId = 1;
        public File(string fullPath)
        {
            if (fullPath == null)
                throw new ArgumentNullException(nameof(fullPath));
            if (!System.IO.File.Exists(fullPath))
                throw new FileLoadException();
            Id = newId++;
            this.fullPath = fullPath;
            FileName = Path.GetFileName(fullPath);
            DirectoryPath = Path.GetDirectoryName(fullPath);
            TotalPages = 1;
        }
    }
}
