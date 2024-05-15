using JobMarket.Data.Repository.Abstract;
using JobMarket.Models;

namespace JobMarket.Data.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _context.ApplicationUsers.ToListAsync();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
