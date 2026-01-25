using KombajnPDF.Data.Abstract;
using System.ComponentModel;

namespace KombajnPDF.Data.Entity
{
    public class FileItemsBindingList : BindingList<FileItem>, IFilesBindingList
    {
        /// <inheritdoc/>
        public IFileItem this[int index] => base[index];

        /// <inheritdoc/>
        public List<IFileItem> Items
            => base.Items.Cast<IFileItem>().ToList();

        /// <inheritdoc/>
        public void Add(IFileItem fileItem)
        {
            if (fileItem is not FileItem concrete)
                throw new ArgumentException(
                    "Object is not of type FileItem",
                    nameof(fileItem));

            base.Add(concrete);
        }

        /// <inheritdoc/>
        public void Insert(int index, IFileItem fileItem)
        {
            if (fileItem is not FileItem concrete)
                throw new ArgumentException(
                    "Object is not of type FileItem",
                    nameof(fileItem));

            base.Insert(index, concrete);
        }
    }
}
