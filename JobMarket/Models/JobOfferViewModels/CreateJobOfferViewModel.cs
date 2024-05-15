using System.ComponentModel.DataAnnotations;

namespace JobMarket.Models.JobOfferViewModels
{
    public class CreateJobOfferViewModel
    {
        public required string JobOfferId { get; set; }

        [Required]
        public required string AuthorId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public required string JobCategoryId { get; set; }

        [Required]
        [Display(Name = "Type")]
        public required string JobTypeId { get; set; }

        [Required]
        [PostalCode]
        [Display(Name = "Postal code", Prompt = "xx-xxx")]
        public required string PostalCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Title")]
        public required string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [Display(Name = "Description")]
        public required string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.0, 1_000_000.0, ErrorMessage = "Wage must be between 0.0 and 1000000.0")]
        [Display(Name = "Wage")]
        public decimal Wage { get; set; }

        public required IEnumerable<JobCategory> JobCategories { get; set; }

        public required IEnumerable<JobType> JobTypes { get; set; }
    }

    internal class PostalCodeAttribute : Attribute
    {
    }
}
