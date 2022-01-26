using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt_asp.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Http;

namespace projekt_asp.Controllers
{
    public class MsgController : Controller
    {
        private readonly IMsgCRUDModel repository;
        private readonly IRegisterCRUDModel bases;
        public MsgController(IMsgCRUDModel repository, IRegisterCRUDModel bases)
        {
            this.repository = repository;
            this.bases = bases;
        }
        public IActionResult Index(MsgModel model)
        {
            ViewData["login"] = HttpContext.Session.GetString("login");
            ViewData["Data"] = bases.FindAll();
            ViewData["your_msg"] = repository.FindMsg(ViewData["login"].ToString());
            return View(model);
        }
        public IActionResult Send(MsgModel data)
        {
            ViewData["login"] = HttpContext.Session.GetString("login"); 
            
            RegisterModel login = bases.FindAll().Where(x => x.Login.Equals(ViewData["login"])).First();
            repository.SendMsg(data,login);
            ViewData["Data"] = bases.FindAll();
            return View("Confirm");
        }
        public IActionResult Display(int id)
        {
            
            repository.Readed(id);
            ViewData["login"] = HttpContext.Session.GetString("login");
            return View(repository.FindMsgById(id));
        }
        public IActionResult Delete(int id)
        {

            repository.Delete(id);
            ViewData["login"] = HttpContext.Session.GetString("login");
            ViewData["Data"] = bases.FindAll();
            ViewData["your_msg"] = repository.FindMsg(HttpContext.Session.GetString("login"));
            return View("Index");
;
        }
    }
}
