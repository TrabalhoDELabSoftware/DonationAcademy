﻿using DonationAcademy.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DonationAcademy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnurl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("List", "Material");
                    }

                    return Redirect(loginVM.ReturnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "Credenciais incorretas!");
            return View("Login", loginVM);

        }

        

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CadastroViewModel registroVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registroVM.UserName,
                    Email = registroVM.EmailRegister,
                };

                var userWithSameUsername = await _userManager.FindByNameAsync(registroVM.UserName);
                if (userWithSameUsername != null)
                {
                    this.ModelState.AddModelError("UserName", "Já existe um usuário com esse nome");
                    return View(registroVM);
                }

                // Verifica se o endereço de e-mail já existe
                var userWithSameEmail = await _userManager.FindByEmailAsync(registroVM.EmailRegister);
                if (userWithSameEmail != null)
                {
                    this.ModelState.AddModelError("EmailRegister", "Já existe um usuário com esse endereço de e-mail");
                    return View(registroVM);
                }


                var result = await _userManager.CreateAsync(user, registroVM.Password);


                if (result.Succeeded)
                {

                    TempData["Mensagem"] = "\nCadastro realizado com sucesso! Efetue o login.\n";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
                }
            }

            return View(registroVM);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
