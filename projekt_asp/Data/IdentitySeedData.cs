using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
    public static class IdentitySeedData
    {

        private const string Password = "zaq1@WSX";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<IdentityUser>)scope
               .ServiceProvider.GetService(typeof(UserManager<IdentityUser>));
                //Tutaj inicjujemy tylko dane do tabeli identity
                List<IdentityUser> users = new()
                {
                    new IdentityUser { UserName = "Tomek", Email = "testowytomek@gmail.com", EmailConfirmed = false, Id = "1" },
                    new IdentityUser { UserName = "Marek", Email = "testowyMarek@gmail.com", EmailConfirmed = false, Id = "2" },
                    new IdentityUser { UserName = "Anna", Email = "testowaAnna@gmail.com", EmailConfirmed = false, Id = "3" },
                    new IdentityUser { UserName = "Filip", Email = "testowyFilip@gmail.com", EmailConfirmed = false, Id = "4" },
                    new IdentityUser { UserName = "Olaf", Email = "testowyOlaf@gmail.com", EmailConfirmed = false, Id = "5" },
                    new IdentityUser { UserName = "Remigiusz", Email = "testowyRemek@gmail.com", EmailConfirmed = false, Id = "6" },
                    new IdentityUser { UserName = "Wojciech", Email = "testowyWojtek@gmail.com", EmailConfirmed = false, Id = "7" },
                    new IdentityUser { UserName = "Szymon", Email = "testowySzymon@gmail.com", EmailConfirmed = false, Id = "8" },
                    new IdentityUser { UserName = "Emilia", Email = "testowaEmilia@gmail.com", EmailConfirmed = false, Id = "9" },
                    new IdentityUser { UserName = "Weronika", Email = "testowaWeronika@gmail.com", EmailConfirmed = false, Id = "10" }
                };


                IdentityUser userTest = await
           userManager.FindByIdAsync("1");
                if (userTest == null)
                {
                    foreach (IdentityUser x in users)
                    {
                        await userManager.CreateAsync(x, Password);
                    }
                }

            }
        }
    }
}
