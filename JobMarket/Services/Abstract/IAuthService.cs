using JobMarket.Helpers;
using JobMarket.Models;
using MySqlX.XDevAPI.Common;
using System.Security.Claims;

namespace JobMarket.Services.Abstract
{
    public class IAuthService
    {
        private object _userManager;

        public async Task<bool> AddRoleToUser(ApplicationUser user, string roleName)
        {
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> IsInRole(ApplicationUser user, string roleName)
        {
            if (user == null)
            {
                return false;
            }

            return await UserManager.IsInRoleAsync(user, roleName);
        }
        internal Task AddRoleToUser(ApplicationUser user, string? name)
        {
            throw new NotImplementedException();
        }

        internal void GetSignedUser(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        internal async Task GetUserRoles(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        internal Task<bool> IsInRole(ApplicationUser user, string moderator)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool> IsSignedIn(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool> Login(string email, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        internal async Task Logout()
        {
            throw new NotImplementedException();
        }

        internal Task Register(string v1, string v2, bool signIn, string roleName)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool> Register(string email, string password)
        {
            throw new NotImplementedException();
        }

        internal Task RemoveRolesFromUser(ApplicationUser user, object userRoles)
        {
            throw new NotImplementedException();
        }

        private async Task<ApplicationUser> CreateUser(string userName, string password, ApplicationUser? user)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException($"'{nameof(userName)}' null veya boş olamaz.", nameof(userName));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' null veya boş olamaz.", nameof(password));
            }

           // var user = new ApplicationUser { UserName = userName, Email = userName };
           // var result = await _userManager.CreateAsync(user, password);

            if (!Result.Succeeded)
            {
                user = null;
            }

            return user;
        }

        public interface AuthService
        {
            Task<bool> Register(string userName, string password, bool signIn = true, string roleName = RoleHelper.User);

            Task<bool> Logout();

            Task<bool> Login(string userName, string password, bool rememberMe);

            Task<bool> IsSignedIn(ClaimsPrincipal claimsUser);

            Task<ApplicationUser> GetSignedUser(ClaimsPrincipal claimsUser);

            Task<bool> IsInRole(ApplicationUser user, string roleName);

            Task<IList<string>> GetUserRoles(ApplicationUser user);

            Task<bool> AddRoleToUser(ApplicationUser user, string roleName);

            Task<bool> RemoveRolesFromUser(ApplicationUser user, IList<string> roleNames);

            Task<string> GetUserName(ClaimsPrincipal claimsUser);
        }
    }
}
