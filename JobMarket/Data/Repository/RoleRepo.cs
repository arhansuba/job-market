using JobMarket.Data.Repository.Abstract;
using Microsoft.AspNetCore.Identity;

namespace JobMarket.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IdentityRole>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<IdentityRole> GetById(string id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(IdentityRole role)
        {
            _context.Roles.Add(role);
        }
    }
}
