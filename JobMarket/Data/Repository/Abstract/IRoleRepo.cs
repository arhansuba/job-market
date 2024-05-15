using Microsoft.AspNetCore.Identity;

namespace JobMarket.Data.Repository.Abstract
{
    public interface IRoleRepository
    {
        Task<IEnumerable<IdentityRole>> GetAll();

        Task<IdentityRole> GetById(string id);

        void Add(IdentityRole role);
    }
}
