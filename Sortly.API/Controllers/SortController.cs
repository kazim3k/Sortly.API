using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sortly.API.Models;
using Sortly.API.Services;

namespace Sortly.API.Controllers
{
    [ApiController]
    [Route("api/sort")]
    public class SortController : ControllerBase
    {
        private readonly ISortService sortService;

        private readonly IFileHandler fileHandler;

        public SortController(ISortService sortService, IFileHandler fileHandler)
        {
            this.sortService = sortService;
            this.fileHandler = fileHandler;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] NumbersPayload numbers)
        {
            var sortedNumbers = new NumbersResponse
            {
                SortedNumbers = this.sortService.Sort(numbers.NumbersToSort.ToArray())
            };
            
            this.fileHandler.SaveToFile(sortedNumbers);

            return this.CreatedAtAction(nameof(this.Get), null);
        }

        [HttpGet("result")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<NumbersResponse> Get()
        {
            return this.fileHandler.GetSortedNumbersFromAFile();
        }
    }
}