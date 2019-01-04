using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleViewer.Presentation.Tests
{
    class PeopleReaderViewModelTests
    {
        [Test]
        public async Task People_OnRefreshPeople_IsPopulated()
        {
            // Arrange
            var repository = new FakeRepository();
            var viewModel = new PeopleReaderViewModel(repository);

            // Act
            await viewModel.RefreshPeople();

            // Assert
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());
        }

        [Test]
        public async Task People_OnClearPeople_IsEmpty()
        {
            // Arrange
            var repository = new FakeRepository();
            var viewModel = new PeopleReaderViewModel(repository);
            await viewModel.RefreshPeople();
            Assert.AreEqual(2, viewModel.People.Count(), "Invalid arrangement");

            // Act
            viewModel.ClearPeople();

            // Assert
            Assert.AreEqual(0, viewModel.People.Count());
        }
    }
}
