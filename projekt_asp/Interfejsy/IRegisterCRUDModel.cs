using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
   public interface IRegisterCRUDModel
    {
        RegisterModel Add(RegisterModel contact);
        int Find_pozycja(string login);
        string Find_Id(string login, RegisterModel dane);
        bool Find_userL(string login,string haslo);
        bool Find_userR(string login, string email);
        RegisterModel Update(RegisterModel dane);
        void Delete(string id);
        RegisterModel FindById(string id);
        IList<RegisterModel> FindAll();
    }
}
