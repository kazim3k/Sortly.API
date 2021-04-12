using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Sortly.API.Services.Impl
{
    public class SortService : ISortService
    {
        private readonly ILogger<SortService> logger;
        private Stopwatch stopwatch;
        public SortService(ILogger<SortService> logger)
        {
            this.logger = logger;
        }
        public int[] Sort(int [] numbers)
        {
            this.InsertionSort(numbers);
            this.ShellSort(numbers);
            return this.BubbleSort(numbers);
        }

        private int[] BubbleSort(int[] numbers)
        {
            this.stopwatch = Stopwatch.StartNew();
            
            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        var temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            this.logger.LogInformation(
                $"Bubble sort time execution: {this.stopwatch.Elapsed.TotalMilliseconds} milliseconds");
            
            return numbers;
        }

        private void InsertionSort(int[] numbers)
        {
            this.stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < numbers.Length - 1; i++)
            {
                for (var j = i + 1; j > 0; j--)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        var temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            this.logger.LogInformation(
                $"Insertion sort time execution: {this.stopwatch.Elapsed.TotalMilliseconds} milliseconds");
        }

        private void ShellSort(int[] numbers)
        {
            this.stopwatch = Stopwatch.StartNew();
            

            for (int h =  numbers.Length / 2; h > 0; h /= 2)
            {
                for (int i = h; i <  numbers.Length; i += 1)
                {
                    int temp = numbers[i];

                    int j;
                    for (j = i; j >= h && numbers[j - h] > temp; j -= h)
                    {
                        numbers[j] = numbers[j - h];
                    }

                    numbers[j] = temp;
                }
            }

            this.logger.LogInformation(
                $"Shell sort time execution: {this.stopwatch.Elapsed.TotalMilliseconds} milliseconds");
        }
    }
}