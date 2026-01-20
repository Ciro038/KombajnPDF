using NUnit.Framework;
using Moq;
using KombajnPDF.Presenter;
using KombajnPDF.Interface;
using KombajnPDF.Data.Entity;
using KombajnPDF.App.Data.Abstract;

namespace KombajnPDF.UnitTest
{
    [TestFixture]
    public class MainFormPresenterTests
    {
        private Mock<ICombineFormView> viewMock;
        private Mock<IFilesCombiner> combinerMock;
        private Mock<IFilePatternChecker> patternCheckerMock;

        private CombineFormPresenter presenter;

        [SetUp]
        public void SetUp()
        {
            viewMock = new Mock<ICombineFormView>();
            combinerMock = new Mock<IFilesCombiner>();
            patternCheckerMock = new Mock<IFilePatternChecker>();

            presenter = new CombineFormPresenter(
                viewMock.Object,
                combinerMock.Object,
                patternCheckerMock.Object);

        }

        [Test]
        public void Constructor_Should_SetFilesDataSource()
        {
            viewMock.Verify(v => v.SetFilesDataSource(It.IsAny<object>()), Times.Once);

        }

        [Test]
        public void AddFilesButtonClicked_Should_AddFilesFromDialog()
        {
            viewMock
                .Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf", "b.pdf" });

            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);

            viewMock.Verify(v => v.SetFilesDataSource(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void FilesDropped_Should_AddFiles()
        {
            var files = new[] { "a.pdf", "b.pdf" };

            viewMock.Raise(v => v.FilesDropped += null, files);

            // brak wyj¹tku = OK
            Assert.Pass();
        }

        [Test]
        public void CombineFiles_NoFiles_Should_DoNothing()
        {
            viewMock.Raise(v => v.CombineFilesButtonClicked += null);

            combinerMock.Verify(
                c => c.CombineFiles(It.IsAny<List<FileItem>>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void CombineFiles_Should_CallCombiner_And_ShowMessage()
        {
            viewMock
                .Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });

            viewMock
                .Setup(v => v.ShowSaveFileDialogForPdfFile())
                .Returns("out.pdf");

            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);
            viewMock.Raise(v => v.CombineFilesButtonClicked += null);

            combinerMock.Verify(
                c => c.CombineFiles(It.IsAny<List<FileItem>>(), "out.pdf"),
                Times.Once);

            viewMock.Verify(
                v => v.ShowMessageBox(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public void CombineFiles_WhenException_Should_ShowError()
        {
            viewMock
                .Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });

            viewMock
                .Setup(v => v.ShowSaveFileDialogForPdfFile())
                .Returns("out.pdf");

            combinerMock
                .Setup(c => c.CombineFiles(It.IsAny<List<FileItem>>(), It.IsAny<string>()))
                .Throws(new Exception("boom"));

            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);
            viewMock.Raise(v => v.CombineFilesButtonClicked += null);

            viewMock.Verify(v => v.ShowErrorProvider("boom"), Times.Once);
            viewMock.Verify(v => v.SetWaitCursor(false), Times.Once);
        }

        [Test]
        public void PatternEdited_Valid_Should_MarkRowAsValid()
        {
            viewMock
                .Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });

            patternCheckerMock
                .Setup(p => p.TryParse(It.IsAny<FileItem>(), out It.Ref<List<int>>.IsAny))
                .Returns(true);

            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);
            viewMock.Raise(v => v.FilesDataGridViewOnPatternCellEdited += null, 0, "FilePattern");

            viewMock.Verify(v => v.MarkRowAsValid(0), Times.Once);
        }

        [Test]
        public void PatternEdited_Invalid_Should_MarkRowAsInvalid_And_ShowError()
        {
            viewMock
                .Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });

            patternCheckerMock
                .Setup(p => p.TryParse(It.IsAny<FileItem>(), out It.Ref<List<int>>.IsAny))
                .Returns(false);

            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);
            viewMock.Raise(v => v.FilesDataGridViewOnPatternCellEdited += null, 0, "FilePattern");

            viewMock.Verify(v => v.MarkRowAsInvalid(0), Times.Once);
            viewMock.Verify(v => v.ShowErrorProvider(It.IsAny<string>()), Times.Once);
        }
    }
}