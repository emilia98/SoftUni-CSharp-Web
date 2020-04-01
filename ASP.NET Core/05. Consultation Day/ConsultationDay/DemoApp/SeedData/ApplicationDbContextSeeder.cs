using DemoApp.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp.SeedData
{
    // user
    // roles

    public class ApplicationDbContextSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
        }

        public async Task SeedDbAsync()
        {
            await SeedUsersAsync();
            await SeedRolesAsync();
            await SeedUserToRolesAsync();
        }

        private async Task SeedUsersAsync()
        {
            var user = await userManager.FindByNameAsync("john@abv.bg");

            if(user != null)
            {
                return;
            }

            await userManager.CreateAsync(new IdentityUser
            {
                UserName = "john@abv.bg",
                Email = "john@abv.bg",
                EmailConfirmed = true
            }, "qwerty");
        }

        private async Task SeedRolesAsync()
        {
            var role = await roleManager.FindByNameAsync("Admin");

            if(role != null)
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });
        }

        private async Task SeedUserToRolesAsync()
        {
            var user = await userManager.FindByNameAsync("john@abv.bg");
            var role = await roleManager.FindByNameAsync("Admin");

            var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
