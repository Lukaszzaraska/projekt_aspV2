using Microsoft.AspNetCore.Mvc;
using projekt_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
    public interface IRest
    {
        public List<RegisterModel> FindUser();

        public void DeleteUser(string id);

        public RegisterModel FindUser(string id);

        public RegisterModel AddUser([FromBody] RegisterModel user);


        public void EditUser(string id, [FromBody] RegisterModel user);


    }
}
