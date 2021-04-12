using System.IO;
using System.Text.Json;
using Sortly.API.Models;

namespace Sortly.API.Services.Impl
{
    public class FileHandler : IFileHandler
    {
        private const string TempFileName = "result.txt";
        public void SaveToFile(NumbersResponse numbersResponse)
        {
            var json = JsonSerializer.Serialize(numbersResponse);
            File.Delete(TempFileName);
            File.WriteAllText(TempFileName, json);
        }

        public NumbersResponse GetSortedNumbersFromAFile()
        {
            return JsonSerializer.Deserialize<NumbersResponse>(File.ReadAllText(TempFileName));
        }
    }
}