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

        public async Task<string> LoadFile()
        {
            await Task.Delay(1);
            switch (dataType)
            {
                case "Good": return TestData.WithGoodRecords;
                case "Mixed": return TestData.WithGoodAndBadRecords;
                case "Bad": return TestData.WithOnlyBadRecords;
                case "Empty": return string.Empty;
                default: return TestData.WithGoodRecords;
            }
        }
    }
}
