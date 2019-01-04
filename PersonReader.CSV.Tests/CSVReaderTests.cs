using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonReader.CSV.Tests
{
    public class CSVReaderTests
    {
        [Test]
        public async Task GetPeople_WithEmptyFile_ReturnsEmptyList()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Empty");

            var result = await repository.GetPeople();

            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetTask_WithNoFile_ThrowsFileNotFoundException()
        {
            var repository = new CSVReader();

            try
            {
                var result = await repository.GetPeople();
                Assert.Fail();
            }
            catch (FileNotFoundException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task GetPeople_WithGoodRecords_ReturnsGoodRecords()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Good");

            var result = await repository.GetPeople();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetPeople_WithBadRecords_ReturnsGoodRecords()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Mixed");

            var result = await repository.GetPeople();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetPeople_WithOnlyBadRecord_ReturnsEmptyList()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Bad");

            var result = await repository.GetPeople();

            Assert.IsEmpty(result);
        }

    }
}
