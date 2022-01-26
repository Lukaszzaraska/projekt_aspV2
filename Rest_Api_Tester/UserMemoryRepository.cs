using Microsoft.AspNetCore.Mvc;
using projekt_asp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Api_Tester
{
    class UserMemoryRepository : IRest
    {
        private Dictionary<string, RegisterModel> Users = new();
        private string Index = "0";


        public RegisterModel AddUser([FromBody] RegisterModel user)
        {
            Users.Add(Index, user);
            Index = (int.Parse(Index) + 1).ToString();
            return user;
        }


        public void DeleteUser(string id)
        {
            Users.Remove(id);
        }

        public void EditUser(string id, [FromBody] RegisterModel user)
        {

            Users[id].Email = user.Email;
            Users[id].Surname = user.Surname;

        }

        public List<RegisterModel> FindUser()
        {
            return Users.Values.ToList();
        }

        public RegisterModel FindUser(string id)
        {
            return Users[id];
        }
    }
}
