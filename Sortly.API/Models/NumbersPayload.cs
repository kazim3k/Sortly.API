using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sortly.API.Validators;

namespace Sortly.API.Models
{
    public class NumbersPayload
    {
        [Required]
        [RangeOfIntegerValuesOfTheArray(1, 10)]
        public IEnumerable<int> NumbersToSort { get; set; } 
    }
}