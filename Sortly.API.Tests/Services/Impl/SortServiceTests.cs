using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Sortly.API.Services;
using Sortly.API.Services.Impl;

namespace Sortly.API.Tests.Services.Impl
{
    public class SortServiceTests
    {
        private ISortService target;

        [SetUp]
        public void Init()
        {
            this.target = new SortService(new Mock<ILogger<SortService>>().Object);
        }
        
        [TestCase(new [] {5, 3, 4, 2, 1}, new [] {1, 2, 3, 4, 5})]
        [TestCase(new [] {1, 3, 1, 2, 1}, new [] {1, 1, 1, 2, 3})]
        [TestCase(new [] {1, 2, 1, 2, 2}, new [] {1, 1, 2, 2, 2})]
        public void Sort_WhenProvidedNumbersUnordered_ReturnOrdered(int[] unordered, int[] expected)
        {
            var actual = this.target.Sort(unordered);
            
            Assert.AreEqual(expected, actual);
        }
        
        
    }
}