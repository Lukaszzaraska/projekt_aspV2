using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt_asp.Models;

namespace projekt_asp.Models
{
    public interface ITimeCRUDModel
    {

        bool AddTime(TimeModel time, string login);
        RegisterModel FindByLogin(string login);


    }
}
