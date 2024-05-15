using JobMarket.Models;

namespace JobMarket.Data.Repository.Abstract
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAll();

        Task<ApplicationUser> GetById(string id);
    }
}
