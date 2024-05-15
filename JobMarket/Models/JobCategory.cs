namespace JobMarket.Models
{
    public class JobCategory
    {
        public string JobCategoryId { get; set; }

        public string Name { get; set; }

        public ICollection<JobOffer> JobOffers { get; set; }
    }
}
