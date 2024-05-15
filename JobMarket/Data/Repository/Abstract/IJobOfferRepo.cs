using JobMarket.Models;

namespace JobMarket.Data.Repository.Abstract
{
    public interface IJobOfferRepository
    {
        Task<IList<JobOffer>> GetAll();

        Task<JobOffer> GetById(string id);

        void Add(JobOffer item);

        void Update(JobOffer item);

        void Delete(JobOffer item);
    }
}
