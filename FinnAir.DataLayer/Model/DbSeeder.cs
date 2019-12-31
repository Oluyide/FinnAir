using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinnAir.DataLayer.Model
{
    public static class DbSeeder
    {

        public static void SeedDb(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "tester@integration.com",
                Email = "tester@integration.com"

            };

            userManager.CreateAsync(user, "SomePass@1234").Wait();
        }
    }
}
