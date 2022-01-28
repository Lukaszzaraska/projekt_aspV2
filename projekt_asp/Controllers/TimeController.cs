using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt_asp.Models;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using projekt_asp.config;

namespace projekt_asp.Controllers
{
    [DisableBasicAuthentication]
    public class TimeController : Controller
    {

        private readonly IMsgCRUDModel _context;
        private readonly ITimeCRUDModel repository;
        public TimeController(ITimeCRUDModel repository, IMsgCRUDModel context)
        {
            this.repository = repository;
            _context = context;
        }


        public IActionResult Index()
        {
            ViewData["login"] = HttpContext.Session.GetString("login");
            return View();
        }
        public IActionResult Add_time(TimeModel czas)
        {

            ViewData["login"] = HttpContext.Session.GetString("login");
            string login = HttpContext.Session.GetString("login");
            if (repository.AddTime(czas, login) == false)
            {
                ViewBag.ErrorMessage = "You have already added your working hours today";
            }
            else
            {
                ViewData["confirm"] = "You have successfully added your work hours for the day " + DateTime.UtcNow.ToString("dd-MM-yyyy");
            }
            int new_msg = _context.NewMsg(HttpContext.Session.GetString("login"));
            TempData["Login"] = HttpContext.Session.GetString("login");
            if (new_msg > 0)
            {
                TempData["Msg"] = $"You have {new_msg} new Msg";
            }
            else
            {
                TempData["Msg"] = "No new messages";
            }

            return View("../Account/Login");

        }

        public IActionResult Your_time()
        {
            string login = HttpContext.Session.GetString("login");
            ViewData["login"] = login;

            RegisterModel user = repository.FindByLogin(login);

            int suma = 0;
            foreach (TimeModel time in user.TimeModels)
            {
                suma += time.Hours_worked;
            }
            ViewData["time"] = suma;
            return View(user);
        }


    }
}
