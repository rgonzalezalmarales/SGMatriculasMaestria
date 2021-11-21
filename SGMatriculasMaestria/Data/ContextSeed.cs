using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGMatriculasMaestria.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Administrador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Especialista.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Tecnico.ToString()));
        }

        public static async Task SeedAdministradorAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var email = "administrador@gmail.com";
            var defaulUser = new IdentityUser
            {
                Email = email,
                UserName = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if(userManager.Users.All(u => u.Id != defaulUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaulUser.Email);
                if(user is null)
                {
                    await userManager.CreateAsync(defaulUser, "Tesis2021+.");
                    await userManager.AddToRoleAsync(defaulUser, Enums.Roles.Administrador.ToString());
                }
            }
        }
    }
}
