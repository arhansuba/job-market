using JobMarket.Data.Repository.Abstract;
using JobMarket.Models;

namespace JobMarket.Data.Repository
{
    internal class JobOfferRepository : IJobOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public JobOfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<JobOffer>> GetAll()
        {
            return await _context.JobOffers
                .Include(u => u.JobCategory)
                .Include(u => u.JobType)
                .Include(u => u.Author)
                .ToListAsync();
        }

        public async Task<JobOffer> GetById(string id)
        {
            return await _context.JobOffers
                .Include(u => u.JobCategory)
                .Include(u => u.JobType)
                .Include(u => u.Author)
                .FirstOrDefaultAsync(x => x.JobOfferId == id);
        }

        public void Add(JobOffer item)
        {
            _context.Add(item);
        }

        public void Update(JobOffer item)
        {
            _context.Update(item);
        }

        public void Delete(JobOffer item)
        {
            _context.Remove(item);
        }
    }

}
