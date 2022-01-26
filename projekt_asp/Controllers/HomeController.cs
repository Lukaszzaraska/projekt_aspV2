using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projekt_asp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace projekt_asp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public bool Zalogowany = true;
      
        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }
        
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Login(RegisterModel dane)
        {
            if (Zalogowany == true)
            {
                 ViewData["data"] = DateTime.UtcNow.ToString("MM-dd-yyyy");
                return View(dane); //Przenieść do panelu głównego jego wygląd zależny od statusu
            }
            else
            {
                return View("Login_fail");
            }

        }

  
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
