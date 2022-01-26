using LinqToDB;
using LinqToDB.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
    public class RegisterCRUDModel : IRegisterCRUDModel
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public RegisterCRUDModel(ApplicationDbContext context, UserManager<IdentityUser> userManager,
       SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        public RegisterModel Add(RegisterModel user)
        {
            IdentityUser identityUser = new IdentityUser { UserName = user.Login, Email = user.Email };
            Task<IdentityResult> result =  _userManager.CreateAsync(identityUser, user.Password);
            

                RegisterModel registerModel = new()
                {
                    UserId = identityUser.Id,
                    Login = user.Login,
                    Email = user.Email,
                    Password = user.Password,
                    Name = user.Name,
                    position = user.position,
                    Surname = user.Surname

                };
                RegisterModel entity = _context.Users.Add(registerModel).Entity;
                _context.SaveChanges();
            

            return entity;
        }
       
        public bool Find_userL(string login,string haslo)
        {

            IQueryable<string> userQuery =
            from user in _context.Users
            where user.Login == login && user.Password==haslo
            select user.Login;

            if (string.IsNullOrEmpty(userQuery.FirstOrDefault()))
            {
             
                return false;
            }
            else
            {
                return true;
            }
           
        }
        public bool Find_userR(string login, string email)
        {

            IQueryable<string> userQuery =
            from user in _context.Users
            where user.Login == login || user.Email == email
            select user.Login;

            if (string.IsNullOrEmpty(userQuery.FirstOrDefault()))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public RegisterModel Find(string id)
        {
            return _context.Users.Find(id);
        }

        public void Delete(string id)
        {
      
             _context.Users.Remove(FindById(id));
     
            _context.SaveChanges();
        
        }
        public int Find_pozycja(string login)
        {
            IQueryable<RegisterModel.Position> userQuery =
            from user in _context.Users
            where user.Login == login
            orderby user.position
            select user.position;

            return (int)Enum.Parse(typeof(RegisterModel.Position),userQuery.First().ToString());
            
        }
        public string Find_Id(string login, RegisterModel dane)
        {
            IQueryable<string> userQuery =
           from user in _context.Users
           where user.Login == login
           select user.UserId;

            return userQuery.First().ToString();
        }
        public RegisterModel Update(RegisterModel dane)
        {
            RegisterModel original = _context.Users.Find(dane.UserId);
            original.Email = dane.Email;
            EntityEntry<RegisterModel> entityEntry = _context.Users.Update(original);
            _context.SaveChanges();
            return entityEntry.Entity;
        }
        public RegisterModel FindById(string id)
        {
            return _context.Users.Where(x => x.UserId.Equals(id)).Include(e => e.TimeModels).FirstOrDefault();
        }

        public IList<RegisterModel> FindAll()
        {
            return _context.Users.ToList();
        }
        
    }
}
