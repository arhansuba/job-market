﻿using JobMarket.Models.AccountViewModels;
using JobMarket.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobMarket.Controllers
{
    public class AccountController(IAuthService authService) : Controller
    {
        
       
       
        
            private readonly IAuthService _authService = authService;

        [TempData]
            public string ErrorMessage { get; set; }

            [HttpGet]
            [AllowAnonymous]
            public IActionResult Login(string? returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
            {
            if (string.IsNullOrEmpty(returnUrl))
            {
                throw new ArgumentException($"'{nameof(returnUrl)}' null veya boş olamaz.", nameof(returnUrl));
            }

            ViewData["ReturnUrl"] = returnUrl;
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }

                var result = await _authService.Login(model.Email, model.Password, model.RememberMe);
                if (result)
                {
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid email address or password.");
                return View(model);
            }

            [HttpGet]
            [AllowAnonymous]
            public IActionResult Register(string? returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                    return View(model);
                }

                var result = await _authService.Register(model.Email, model.Password);
                if (result)
                {
                    return RedirectToLocal(returnUrl: returnUrl);
                }

                ModelState.TryAddModelError(string.Empty, "This email address is already taken.");
                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout()
            {
                await _authService.Logout();
                return RedirectToAction(nameof(JobOfferController.Popular), "JobOffer");
            }

            private IActionResult RedirectToLocal(string returnUrl)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction(nameof(JobOfferController.Popular), "JobOffer");
            }
        }
    }

