namespace KombajnPDF.Data.Abstract
{
    internal interface IFilesBindingList
    {
        List<IFileItem> Items { get; }
        public IFileItem this[int index] { get; }
        /// <summary>
        /// Adds an object to the end of the collection based on full path to the file
        /// </summary>
        /// <param name="fileItem">The file item to add</param>
        public void Add(IFileItem fileItem);
        /// <summary>
        /// Removes the element at the specified index od collection
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the e,emet to remove</param>
        public void RemoveAt(int rowIndex);
        /// <summary>
        /// Insert an element into collection at the specified index
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted</param>
        /// <param name="fileItem">The file item to insert</param>
        public void Insert(int index, IFileItem fileItem);

    }
}
