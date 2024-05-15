using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace JobMarket.Helpers.CustomValidators
{
    public partial class PostalCodeBaseBase
    {
        [GeneratedRegex("^[0-9]{2}[-][0-9]{3}$")]
        private static partial Regex MyRegex();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(validationContext.DisplayName + " is required.");
            }

            var postalCode = value.ToString();
            if (MyRegex().IsMatch(postalCode))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid post code (use format: xx-xxx).");
        }

        private object MyRegex()
        {
            throw new NotImplementedException();
        }
    }
}