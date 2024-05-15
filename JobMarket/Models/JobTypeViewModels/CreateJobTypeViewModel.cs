using JobMarket.Models.JobCategoryViewModels;
using System.ComponentModel.DataAnnotations;

namespace JobMarket.Models.JobTypeViewModels
{
    public class CreateJobTypeViewModel
    {
        
        
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Capitalized]
            [Display(Name = "Name")]
            public required string Name { get; set; }
        


    }
}
