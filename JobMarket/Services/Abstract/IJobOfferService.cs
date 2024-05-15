using JobMarket.Models;

namespace JobMarket.Services.Abstract
{
    public interface IJobOfferService
    {
        Task<IList<JobOffer>> GetAllOffers();

        Task<JobOffer> GetOfferById(string id);

        Task<bool> Add(JobOffer item);

        Task<bool> Edit(JobOffer item);

        Task<bool> Delete(JobOffer offer);

        Task<IEnumerable<JobOffer>> GetMostPopularOffers();

        Task<IEnumerable<JobOffer>> GetOffersContainingPhrase(string phrase);

        Task<bool> CanUserEditOffer(string userId, string offerId);

        Task<bool> IncreaseOfferViews(JobOffer offer);
        Task<bool> Delete(string id);
        Task CanUserEditOffer(object ıd, object jobOfferId);
    }
}
