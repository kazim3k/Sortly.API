using Sortly.API.Models;

namespace Sortly.API.Services
{
    public interface IFileHandler
    {
        void SaveToFile(NumbersResponse numbersResponse);

        NumbersResponse GetSortedNumbersFromAFile();
    }
}