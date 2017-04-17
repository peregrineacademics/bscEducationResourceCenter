#region Using

using System.Threading.Tasks; 
using Microsoft.AspNetCore.Identity;
using System;

#endregion

namespace PAS.ResourceCenter.Web.Administration.Models
{
    public class DatabaseInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DatabaseInitializer(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await CreateUsersAsync();
        }

        private async Task CreateUsersAsync()
        {
            var user = await _userManager.FindByEmailAsync("admin@peregrineacademics.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "admin@peregrineacademics.com",
                    Email = "admin@peregrineacademics.com",
                    LastName = "Administrator",
                    FirstName = "PAS",
                    MiddleName = "",
                    Title = "",
                    IsEnabled = true,
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, "password");
                
            }
        }
    }
}