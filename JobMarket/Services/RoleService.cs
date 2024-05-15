using JobMarket.Data;
using JobMarket.Data.Repository.Abstract;
using JobMarket.Helpers;
using JobMarket.Models;
using JobMarket.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace JobMarket.Services
{
    public class RoleService(
        IRoleRepository roleRepo,
        IApplicationUserRepository userRepo,
        IUnitOfWork unitOfWork,
        IAuthService authService) : IRoleService
    {
        private readonly IRoleRepository _roleRepo = roleRepo;
        private readonly IApplicationUserRepository _userRepo = userRepo;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAuthService _authService = authService;

        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            return await _roleRepo.GetAll();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _userRepo.GetAll();
        }

        public async Task<IdentityRole> GetUserRole(string userId)
        {
            var user = await _userRepo.GetById(userId);

            var userRoleNames = await _authService.GetUserRoles(user);
            var userRoleName = userRoleNames.FirstOrDefault();

            var roles = await _roleRepo.GetAll();
            return roles.FirstOrDefault(x => x.NormalizedName == RoleHelper.Normalize(userRoleName));
        }

        public async Task<bool> ChangeUserRole(string userId, string newRoleId)
        {
            var user = await _userRepo.GetById(userId);
            var newRole = await _roleRepo.GetById(newRoleId);
            var userRoles = await _authService.GetUserRoles(user);

            await _authService.RemoveRolesFromUser(user, userRoles);
            await _authService.AddRoleToUser(user, newRole.Name);

            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> IsUserAdministrator(string userId)
        {
            var userRole = await GetUserRole(userId);
            return string.Equals(userRole.NormalizedName, RoleHelper.Normalize(RoleHelper.Administrator));
        }

        public async Task AddRole(string roleName)
        {
            var role = new IdentityRole(roleName) { NormalizedName = RoleHelper.Normalize(roleName) };
            _roleRepo.Add(role);
            await _unitOfWork.Save();
        }

        public bool IsUserAdministrator(object ıd)
        {
            throw new NotImplementedException();
        }

        public object GetUserRole(object ıd)
        {
            throw new NotImplementedException();
        }
    }
}
