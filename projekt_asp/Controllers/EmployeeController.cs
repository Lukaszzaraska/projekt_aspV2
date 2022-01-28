using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projekt_asp.config;
using projekt_asp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Controllers
{
    [DisableBasicAuthentication]
    public class EmployeeController : Controller
    {
        private readonly IRegisterCRUDModel repository;
        static int ranga;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public EmployeeController(IRegisterCRUDModel repository, UserManager<IdentityUser> userManager,
       SignInManager<IdentityUser> signInManager)
        {
            this.repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult Add(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                if (repository.Find_userR(user.Login, user.Email))
                {
                    ViewData["login"] = HttpContext.Session.GetString("login");
                    return View("Confirm", repository.Add(user));
                }
                ViewBag.ErrorMessage = "Login or Email is already registered";
                return View("Register");
            }
            else
            {
                return View("Register");
            }
        }

        public IActionResult Register()
        {
            return View();
        }



        public IActionResult Lists_workers()
        {

            ranga = repository.Find_pozycja(HttpContext.Session.GetString("login"));
            ViewData["rang"] = ranga;
            ViewData["login"] = HttpContext.Session.GetString("login");
            return View(repository.FindAll());
        }
        public async Task<IActionResult> Delete(string id)
        {
            ViewData["rang"] = ranga;
            ViewData["login"] = HttpContext.Session.GetString("login");
            repository.Delete(id);
            IdentityUser user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return View("Lists_workers", repository.FindAll());
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Edit(RegisterModel update)
        {
            ViewData["rang"] = ranga;
            ViewData["login"] = HttpContext.Session.GetString("login");
            repository.Update(update);
            return View("Lists_workers", repository.FindAll());
        }
        public IActionResult EditUser(string id)
        {
            ViewData["login"] = HttpContext.Session.GetString("login");
            return View(repository.FindById(id));
        }



        public IActionResult Works()
        {
            return View();
        }


    }
}