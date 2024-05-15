using Microsoft.AspNetCore.Identity;

namespace JobMarket.Services.Abstract
{
    public interface IRoleService
    {
        Task<IEnumerable<IdentityRole>> GetAllRoles();

        Task<IdentityRole> GetUserRole(string userId);

        Task<bool> ChangeUserRole(string userId, string newRoleId);

        Task<bool> IsUserAdministrator(string userId);

        Task AddRole(string roleName);
        bool IsUserAdministrator(object ıd);
        object GetUserRole(object ıd);
    }
}
