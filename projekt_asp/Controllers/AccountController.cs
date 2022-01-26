using CommonServiceLocator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using projekt_asp.config;
using projekt_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace projekt_asp.Controllers
{
    
  
        [Authorize]
        public class AccountController : Controller
        {

            private readonly UserManager<IdentityUser> _userManager;
            private readonly SignInManager<IdentityUser> _signInManager;
            private readonly IMsgCRUDModel _context;
        public AccountController(UserManager<IdentityUser> userManager,
           SignInManager<IdentityUser> signInManager, IMsgCRUDModel context)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _context = context;
        }

       
        [AllowAnonymous]
            [HttpGet]
            
            public IActionResult Login(string returnUrl)
            {
                TempData["Login"] = HttpContext.Session.GetString("login");
            int new_msg = _context.NewMsg(HttpContext.Session.GetString("login"));

            if (new_msg > 0)
            {
                TempData["Msg"] = $"You have {new_msg} new Msg";
            }
            else
            {
                TempData["Msg"] = "No new messages";
            }
            return View(new LoginModel
                {

                    ReturnUrl = returnUrl
                });

            }
            
            [AllowAnonymous]
            [HttpPost]
            [ValidateAntiForgeryToken]
           
            public async Task<IActionResult> Login(LoginModel loginModel)
            {

                if (ModelState.IsValid)
                {

                    IdentityUser user = await
                   _userManager.FindByNameAsync(loginModel.Name);
                    if (user != null)
                    {
                        await _signInManager.SignOutAsync();
                        if ((await _signInManager.PasswordSignInAsync(user,
                        loginModel.Password, false, false)).Succeeded)
                        {
                            HttpContext.Session.SetString("login", loginModel.Name.ToString());
                            ViewData["login"] = HttpContext.Session.GetString("login");
                            TempData["Login"] = loginModel.Name.ToString();  
                        int new_msg = _context.NewMsg(loginModel.Name.ToString());
                        HttpContext.Session.SetInt32("new_msg", new_msg);
                        if (new_msg>0)
                        {
                            TempData["Msg"] = $"You have {new_msg} new Msg";
                        }
                        else
                        {
                            TempData["Msg"] = "No new messages";
                        }
                            return Redirect(loginModel?.ReturnUrl ?? "/Account/Login");
                        }
                    }
                }
                ModelState.AddModelError("CustomError", "Invalid user name or password");
                return View("../Employee/Login_fail", loginModel);

            }

            [AllowAnonymous]
            [HttpGet]
            public async Task<RedirectResult> Logout(string returnUrl = "/")
            {
                await _signInManager.SignOutAsync();
                return Redirect(returnUrl);

            }
        }
    }
