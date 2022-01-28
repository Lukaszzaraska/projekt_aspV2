using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using projekt_asp.config;
using projekt_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace projekt_asp.Controllers
{
   

        [Route("api/employee")]
        [ApiController]
        public class Rest_Controller : ControllerBase
        {
            private IRegisterCRUDModel _context;

            public Rest_Controller(IRegisterCRUDModel context)
            {
                _context = context;
            }

             [DisableBasicAuthentication]
             [HttpGet]
            public IList<RegisterModel> FindUser()
            {
            return _context.FindAll();
            }

            
            [HttpDelete]
            [Route("{id}")]
            public RegisterModel DeleteUser(string id)
            {
                RegisterModel DeleteUser = _context.FindByIdApi(id);
               _context.Delete(id);
               return DeleteUser;
            }


        [DisableBasicAuthentication]
        [HttpGet]
            [Route("{id}")]
            public RegisterModel FindUser(string id)
            {
            return _context.FindByIdApi(id);
            }

        [DisableBasicAuthentication]
        [HttpPost]
            public RegisterModel AddUser([FromBody] RegisterModel user)
            {
            RegisterModel entity =  _context.Add(user);

                return entity;
            }

        [HttpPut("{id}")]
        public ActionResult<RegisterModel> EditUser([FromBody] RegisterModel user)
            {
            
            RegisterModel repo = _context.Update(user);
                if (repo != null)
                {
                repo.Email = user.Email;
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
        }
    }
