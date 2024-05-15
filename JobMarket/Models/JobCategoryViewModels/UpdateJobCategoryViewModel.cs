namespace JobMarket.Models.JobCategoryViewModels
{
    public class UpdateJobCategoryViewModel(string categoryName, int minLength, int maxLength)
    {
        public string CategoryName { get; set; } = categoryName;
        public int MinLength { get; set; } = minLength;
        public int MaxLength { get; set; } = maxLength;

        public void DisplayValidationMessage()
        {
            Console.WriteLine($"The {CategoryName} must be at least {MinLength} and at max {MaxLength} characters long.");
        }
    }
}
