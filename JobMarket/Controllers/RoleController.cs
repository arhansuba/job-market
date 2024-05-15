using JobMarket.Data.Repository.Abstract;
using JobMarket.Helpers;
using JobMarket.Models.RoleViewModels;
using JobMarket.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobMarket.Controllers
{
    public class RoleController(IRoleService roleService, IApplicationUserRepository userRepo) : Controller
    {
       // [Authorize(Roles = RoleHelper.Administrator)]
       
        
            private readonly IRoleService _roleService = roleService;
            private readonly IApplicationUserRepository _userRepo = userRepo;

        // GET: Role
        public async Task<IActionResult> Index()
            {
                var users = await _userRepo.GetAll();
                var roles = await _roleService.GetAllRoles();

                var viewModels = users.Select(user =>
                    new RoleViewModel
                    {
                        ApplicationUser = user,
                        ApplicationUserId = (string)user.Id,
                       // RoleId = _roleService.GetUserRole(user.Id).Result.Id,
                        Roles = roles,
                       // Disabled = _roleService.IsUserAdministrator(user.Id).Result
                    }
                );

                return View(viewModels);
            }

            // POST: Role/ChangeRole
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> ChangeRole(string applicationUserId, string newRoleId)
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }

                var result = await _roleService.ChangeUserRole(applicationUserId, newRoleId);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("NotFound");
            }
        }
    }

