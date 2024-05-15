namespace JobMarket.Models.JobTypeViewModels
{
    public class UpdateJobTypeViewModel
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }

        public UpdateJobTypeViewModel(string typeName, string description, int minExperience, int maxExperience)
        {
            TypeName = typeName;
            Description = description;
            MinExperience = minExperience;
            MaxExperience = maxExperience;
        }

        public void DisplayValidationMessage()
        {
            Console.WriteLine($"The job type '{TypeName}' must have a description and require a minimum experience of {MinExperience} years and at most {MaxExperience} years.");
        }
    }
}
