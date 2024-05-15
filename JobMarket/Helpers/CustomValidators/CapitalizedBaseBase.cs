using System.ComponentModel.DataAnnotations;

namespace JobMarket.Helpers.CustomValidators
{
    public class CapitalizedBaseBase
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(validationContext.DisplayName + " is required.");
            }

            if (!char.IsUpper(c: value.ToString().First()))
            {
                return (ValidationResult?)new ValidationResult(validationContext.DisplayName + " must start with capital letter.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}