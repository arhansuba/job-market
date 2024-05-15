using System.ComponentModel.DataAnnotations;

namespace JobMarket.Models.JobCategoryViewModels
{
    public class EditJobCategoryViewModel
    {
        public required string JobCategoryId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Capitalized]
        [Display(Name = "Name")]
        public required string Name { get; set; }
    }

    [AttributeUsage(AttributeTargets.All)]
    internal class CapitalizedAttribute : Attribute
    {
    }
}
