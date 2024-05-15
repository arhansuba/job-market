using JobMarket.Data.Repository.Abstract;
using JobMarket.Models;
using JobMarket.Services.Abstract;

namespace JobMarket.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _userRepository;

        public ApplicationUserService(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }
    }
}
