using JobMarket.Models;

namespace JobMarket.Data.Repository.Abstract
{
    public interface IJobTypeRepository
    {
        Task<IEnumerable<JobType>> GetAll();

        Task<JobType> GetById(string id);

        void Add(JobType item);

        void Update(JobType item);

        void Delete(JobType item);
    }
}
