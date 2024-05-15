using JobMarket.Models;

namespace JobMarket.Data.Repository.Abstract
{
    public interface IJobCategoryRepository
    {
        Task<IEnumerable<JobCategory>> GetAll();

        Task<JobCategory> GetById(string id);

        void Add(JobCategory item);

        void Update(JobCategory item);

        void Delete(JobCategory item);
    }
}
