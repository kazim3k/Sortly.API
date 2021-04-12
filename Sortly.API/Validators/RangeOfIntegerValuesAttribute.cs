using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sortly.API.Validators
{
    public class RangeOfIntegerValuesOfTheArrayAttribute : ValidationAttribute
    {
        private const string ValidationErrorMessage = "Numbers must be between {0} - {1}";
        private readonly int min;
        private readonly int max;
        public RangeOfIntegerValuesOfTheArrayAttribute(int minimum, int maximum)
        {
            this.min = minimum;
            this.max = maximum;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as List<int>;

            if (list == null || 
                list.Any(item => !Enumerable.Range(this.min, this.max).Contains(item)))
            {
                return new ValidationResult(
                    string.Format(ValidationErrorMessage, this.min, this.max));
            }

            return ValidationResult.Success;
        }
    }
}