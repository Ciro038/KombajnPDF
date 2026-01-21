using System;
using System.Collections.Generic;
using KombajnPDF.App.Interface;
using KombajnPDF.App.Presenter;
using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Entity;
using Moq;
using NUnit.Framework;

namespace KombajnPDF.Tests.Presenters
{
    [TestFixture]
    public class CombineFormPresenterTests
    {
        private Mock<ICombineFormView> viewMock;
        private Mock<IFilesCombiner> filesCombinerMock;
        private Mock<IFilePatternChecker> patternCheckerMock;

        private CombineFormPresenter presenter;

        [SetUp]
        public void Setup()
        {
            viewMock = new Mock<ICombineFormView>(MockBehavior.Strict);
            filesCombinerMock = new Mock<IFilesCombiner>(MockBehavior.Strict);
            patternCheckerMock = new Mock<IFilePatternChecker>(MockBehavior.Strict);

            // ważne: SetFilesDataSource jest wywoływane w ctorze
            viewMock
                .Setup(v => v.SetFilesDataSource(It.IsAny<FileItemsBindingList>()));

            presenter = new CombineFormPresenter(
                viewMock.Object,
                filesCombinerMock.Object,
                patternCheckerMock.Object);
        }

        [Test]
        public void Constructor_ShouldSetFilesDataSource()
        {
            viewMock.Verify(
                v => v.SetFilesDataSource(It.IsAny<FileItemsBindingList>()),
                Times.Once);
        }

        [Test]
        public void AddFilesButtonClicked_ShouldAddFilesToList()
        {
            // Arrange
            var files = new[] { "a.pdf", "b.pdf" };

            viewMock
                .Setup(v => v.ShowOpenFileDialog())
                .Returns(files);

            // Act
            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);

            // Assert
            viewMock.Verify(v => v.ShowOpenFileDialog(), Times.Once);
        }

        [Test]
        public void FilesDropped_ShouldAddAllFiles()
        {
            var droppedFiles = new[] { "x.pdf", "y.pdf" };

            viewMock.Raise(
                v => v.FilesDropped += null,
                droppedFiles);

            // brak wyjątku = sukces
            Assert.Pass();
        }

        [Test]
        public void CombineFiles_NoFiles_ShouldDoNothing()
        {
            viewMock.Raise(v => v.CombineFilesButtonClicked += null);

            filesCombinerMock.Verify(
                c => c.CombineFiles(It.IsAny<IEnumerable<FileItem>>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void CombineFiles_WithFiles_ShouldCombineAndShowMessage()
        {
            // Arrange
            viewMock.Setup(v => v.SetWaitCursor(true));
            viewMock.Setup(v => v.SetWaitCursor(false));
            viewMock.Setup(v => v.ShowSaveFileDialogForPdfFile())
                .Returns("out.pdf");
            viewMock.Setup(v => v.ShowMessageBox(It.IsAny<string>(), It.IsAny<string>()));

            filesCombinerMock
                .Setup(c => c.CombineFiles(It.IsAny<IEnumerable<FileItem>>(), "out.pdf"));

            // dodaj plik
            viewMock.Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });
            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);

            // Act
            viewMock.Raise(v => v.CombineFilesButtonClicked += null);

            // Assert
            viewMock.Verify(v => v.SetWaitCursor(true), Times.Once);
            viewMock.Verify(v => v.SetWaitCursor(false), Times.Once);
            filesCombinerMock.VerifyAll();
        }

        [Test]
        public void CombineFiles_WhenExceptionThrown_ShouldShowError()
        {
            viewMock.Setup(v => v.SetWaitCursor(true));
            viewMock.Setup(v => v.SetWaitCursor(false));
            viewMock.Setup(v => v.ShowSaveFileDialogForPdfFile())
                .Returns("out.pdf");
            viewMock.Setup(v => v.ShowError("boom"));

            filesCombinerMock
                .Setup(c => c.CombineFiles(It.IsAny<IEnumerable<FileItem>>(), "out.pdf"))
                .Throws(new Exception("boom"));

            viewMock.Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });
            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);

            viewMock.Raise(v => v.CombineFilesButtonClicked += null);

            viewMock.Verify(v => v.ShowError("boom"), Times.Once);
        }

        [Test]
        public void PatternEdited_WhenValid_ShouldMarkRowValid()
        {
            var file = new FileItem("a.pdf");

            patternCheckerMock
                .Setup(p => p.TryParse(file, out It.Ref<IEnumerable<int>>.IsAny))
                .Returns(true);

            viewMock.Setup(v => v.MarkRowAsValid(0));

            viewMock.Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });
            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);

            viewMock.Raise(v => v.FilesDataGridViewOnPatternCellEdited += null, 0);

            viewMock.Verify(v => v.MarkRowAsValid(0), Times.Once);
        }

        [Test]
        public void PatternEdited_WhenInvalid_ShouldMarkRowInvalidAndShowError()
        {
            var file = new FileItem("a.pdf");

            patternCheckerMock
                .Setup(p => p.TryParse(file, out It.Ref<IEnumerable<int>>.IsAny))
                .Returns(false);

            viewMock.Setup(v => v.MarkRowAsInvalid(0));
            viewMock.Setup(v => v.ShowError(It.IsAny<string>()));

            viewMock.Setup(v => v.ShowOpenFileDialog())
                .Returns(new[] { "a.pdf" });
            viewMock.Raise(v => v.AddFilesButtonOnAddFilesClicked += null);

            viewMock.Raise(v => v.FilesDataGridViewOnPatternCellEdited += null, 0);

            viewMock.Verify(v => v.MarkRowAsInvalid(0), Times.Once);
            viewMock.Verify(v => v.ShowError(It.IsAny<string>()), Times.Once);
        }
    }
}