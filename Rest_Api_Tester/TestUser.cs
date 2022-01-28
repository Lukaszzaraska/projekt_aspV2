
using Xunit;
using projekt_asp.Controllers;
using projekt_asp.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Rest_Api_Tester
{
    public class ApiTest
    {


        [Fact]
        public void AddUser()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new RegisterModel()
            {
                Email = "Marek@gmail.com",
                Login = "TestowyMarek",
                position = RegisterModel.Position.God
              ,
                Name = "Marek",
                Password = "zaq1@WSX",
                Surname = "Poreba"

            });
            repository.AddUser(new RegisterModel()
            {
                Email = "Tomek@gmail.com",
                Login = "TestowyTomek",
                position = RegisterModel.Position.High
               ,
                Name = "Tomasz",
                Password = "zaq1@WSX",
                Surname = "Rozek"

            });
            var repo = repository.FindUser();
            Assert.Equal(2, repo.Count);
            Assert.IsType<List<RegisterModel>>(repo);
        }
        [Fact]
        public void FindById()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new RegisterModel()
            {
                Email = "Marek@gmail.com",
                Login = "TestowyMarek",
                position = RegisterModel.Position.God
              ,
                Name = "Marek",
                Password = "zaq1@WSX",
                Surname = "Poreba"

            });
            var repo = repository.FindUser("0");
            Assert.Equal("Marek", repo.Name);
        }
        [Fact]
        public void DeleteUser()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new RegisterModel()
            {
                Email = "Marek@gmail.com",
                Login = "TestowyMarek",
                position = RegisterModel.Position.God
               ,
                Name = "Marek",
                Password = "zaq1@WSX",
                Surname = "Poreba"

            });
            Assert.NotEmpty(repository.FindUser());
            repository.DeleteUser("0");
            Assert.Empty(repository.FindUser());
        }

        [Fact]
        public void EditUser()
        {
            UserMemoryRepository repository = new();

            repository.AddUser(new RegisterModel()
            {
                Email = "Marek@gmail.com",
                Login = "TestowyMarek",
                position = RegisterModel.Position.God
               ,
                Name = "Marek",
                Password = "zaq1@WSX",
                Surname = "Poreba"

            });
            repository.EditUser("0", new RegisterModel { Surname = "Sztachetka", Email = "plot@gmail.com" });

            Assert.Equal("Sztachetka", repository.FindUser("0").Surname);
            Assert.Equal("plot@gmail.com", repository.FindUser("0").Email);
            Assert.Equal("TestowyMarek", repository.FindUser("0").Login);
        }
    }

}
