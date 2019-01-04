using System.IO;
using System.Threading.Tasks;

namespace PersonReader.CSV
{
    public interface ICSVFileLoader
    {
        Task<string> LoadFile();
    }

    public class CSVFileLoader : ICSVFileLoader
    {
        private string filePath;

        public CSVFileLoader(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task<string> LoadFile()
        {
            using (var reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
