namespace JobMarket.Models.JobOfferViewModels
{
    public class UpdateJobOfferViewModel
    {
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public UpdateJobOfferViewModel(string jobTitle, string description, string location, int minSalary, int maxSalary)
        {
            JobTitle = jobTitle;
            Description = description;
            Location = location;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }

        public void DisplayValidationMessage()
        {
            Console.WriteLine($"The job offer '{JobTitle}' must have a description, a location, and a salary range between {MinSalary} and {MaxSalary}.");
        }
    }
}
