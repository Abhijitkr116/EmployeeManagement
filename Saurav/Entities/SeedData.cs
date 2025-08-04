using Microsoft.AspNetCore.Identity;

namespace Saurav.Entities
{
    public class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider){
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUsers>>();

            // Define the Admin and other roles
            string[] roleNames = { "Admin", "HR", "Employee" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // Check if the role already exists, if not create it
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create an admin user if one does not already exist

            var adminEmail = "admin@example.com";
            var adminName = "admin";
            var adminPassword = "Admin@123";
            var adminUser = await userManager.FindByNameAsync(adminName);
            if (adminUser == null)
            {
                var newAdmin = new ApplicationUsers
                {
                    UserName = adminName,
                    Email = adminEmail,
                    EmailConfirmed = true,

                };

                var createAdminResult = await userManager.CreateAsync(newAdmin, adminPassword);
                if (createAdminResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }



        }
    }
}
