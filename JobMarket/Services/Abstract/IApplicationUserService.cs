using JobMarket.Models;

namespace JobMarket.Services.Abstract
{
    
    
        public interface IApplicationUserService
        {
            Task<IEnumerable<ApplicationUser>> GetAllUsers();
        }
    
}
