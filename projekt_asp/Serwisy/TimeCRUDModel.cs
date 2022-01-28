using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt_asp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace projekt_asp.Models
{
    public class TimeCRUDModel : ITimeCRUDModel
    {
        private ApplicationDbContext _context;

        public TimeCRUDModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<RegisterModel> Users => _context.Users;

        public bool AddTime(TimeModel time, string Login)
        {
            DateTime date_today = DateTime.UtcNow.Date;

            IQueryable<string> userQuery =
            from user in _context.Users
            where user.Login == Login
            select user.UserId;

            RegisterModel registerModel = _context.Users.Find(userQuery.First());

            IQueryable<DateTime> userQuery1 =
          from czas in _context.Times
          where (czas.Date == date_today) && (czas.RegisterModel.UserId == registerModel.UserId)
          select czas.Date;

            string test = "x";


            try
            {
                test = userQuery1.First().ToString();
            }
            catch
            {
                if (test == "x")
                {
                    registerModel.TimeModels.Add(time);
                    time.Date = date_today;
                    _context.Users.Update(registerModel);
                    _context.SaveChanges();
                    return true;
                }

            }


            if (test != date_today.ToString())
            {
                registerModel.TimeModels.Add(time);
                time.Date = date_today;
                _context.Users.Update(registerModel);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }


        }
        public RegisterModel FindByLogin(string login)
        {

            return _context.Users.Where(user => user.Login.Equals(login)).Include(tim => tim.TimeModels).First();
        }

    }

}

