using System.Threading.Tasks;

namespace PersonReader.CSV.Tests
{
    public class FakeFileLoader : ICSVFileLoader
    {
        private string dataType;

        public FakeFileLoader(string dataType)
        {
            this.dataType = dataType;
        }

        public Task<string> LoadFile()
        {
            string fileData = string.Empty;
            switch (dataType)
            {
                case "Good": fileData = TestData.WithGoodRecords;
                    break;
                case "Mixed": fileData = TestData.WithGoodAndBadRecords;
                    break;
                case "Bad": fileData = TestData.WithOnlyBadRecords;
                    break;
                case "Empty": fileData = string.Empty;
                    break;
                default: fileData = TestData.WithGoodRecords;
                    break;
            }

            return Task.FromResult(fileData);
        }
    }
}
