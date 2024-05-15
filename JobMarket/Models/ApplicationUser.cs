namespace JobMarket.Models
{
    public class ApplicationUser
    {
        public ICollection<JobOffer> JobOffers { get; set; }
        public object Id { get; internal set; }
        public object Email { get; internal set; }
        public string UserName { get; internal set; }
    }
}
