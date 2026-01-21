using KombajnPDF.Data.Abstract;
using System.ComponentModel;

namespace KombajnPDF.Data.Entity
{
    public class FileItemsBindingList : BindingList<IFileItem>, IFilesBindingList
    {
        /// <inheritdoc/>
        public new IFileItem this[int index]
        {
            get { return base[index]; }
        }
        /// <inheritdoc/>
        public new List<FileItem> Items
        {
            get { return ((List<FileItem>)base.Items).ConvertAll(file => file); }
        }

        /// <inheritdoc/>
        public new void Add(IFileItem fileItem)
        {
            base.Add(fileItem);
        }
        /// <inheritdoc/>
        public new void RemoveAt(int rowIndex)
        {
            base.RemoveAt(rowIndex);
        }
        /// <inheritdoc/>
        public void Insert(int index, string fullPathToFile)
        {
            Insert(index, new FileItem(fullPathToFile));
        }
    }
}
