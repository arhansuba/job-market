﻿using JobMarket.Helpers;
using JobMarket.Models;
using JobMarket.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace JobMarket.Services
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Register(string userName, string password, bool signIn = true, string roleName = RoleHelper.User)
        {
            var createdUser = await CreateUser(userName, password);
            if (createdUser == null)
            {
                return false;
            }

            var roleAssigned = await AddRoleToUser(createdUser, roleName);
            if (!roleAssigned)
            {
                return false;
            }

            if (signIn)
            {
                await _signInManager.SignInAsync(createdUser, isPersistent: false);
            }

            return true;
        }

        private async Task<ApplicationUser?> CreateUser(string userName, string password)
        {
            var user = new ApplicationUser { UserName = userName, Email = userName };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

        private async Task<bool> AddRoleToUser(ApplicationUser user, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<bool> Login(string userName, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> IsSignedIn(ClaimsPrincipal claimsUser)
        {
            return claimsUser != null && _signInManager.IsSignedIn(claimsUser);
        }

        public async Task<ApplicationUser?> GetApplicationUserAsync(ClaimsPrincipal claimsUser)
        {
            return await _userManager.GetUserAsync(claimsUser);
        }

        public ApplicationUser? GetSignedUser(ClaimsPrincipal claimsUser)
        {
            return claimsUser == null ? null : _userManager.GetUserAsync(claimsUser).Result;
        }

        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> RemoveRolesFromUser(ApplicationUser user, IList<string> roleNames)
        {
            var result = await _userManager.RemoveFromRolesAsync(user, roleNames);
            return result.Succeeded;
        }

        public async Task<string?> GetUserNameAsync(ClaimsPrincipal claimsUser)
        {
            return await _userManager.GetUserNameAsync(claimsUser);
        }
    }
}

