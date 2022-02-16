using Fine.Data;
using Fine.Enums;
using Fine.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerTry.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ChatUser> _userManager;

        // constructor injection
        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ChatUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            // Create db from the Migrations
            // Ensures db is created in event it doesn't exist
            await _dbContext.Database.MigrateAsync();

            // 1: Seed roles into the system
            await SeedRolesAsync();

            // 2: Seed a few users into the system
            await SeedUsersAsync();

            // 3: Seed ChatHistory
            await SeedChatHistory();
        }

        private async Task SeedRolesAsync()
        {
            // If roles already exist, do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            // Otherwise, create a few roles
            foreach (var role in Enum.GetNames(typeof(ChatRoles)))
            {
                // use the role manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {

            if (_dbContext.Users.Any())
            {
                return;
            }



            var adminUser = new ChatUser()
            {
                DisplayName = "wanoadmin",
                UserName = "wanoadmin",
                EmailConfirmed = true
            };
            var testUser = new ChatUser()
            {
                DisplayName = "wanouser",
                UserName = "wanouser",
                EmailConfirmed = true
            };
            // Then, use _userManager to create said user as defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc123!");

            // Then, add this to db
            await _userManager.AddToRoleAsync(adminUser, ChatRoles.Administrator.ToString());

            // another user
            await _userManager.CreateAsync(testUser, "Abc123!");

            // another user
            await _userManager.AddToRoleAsync(testUser, ChatRoles.User.ToString());
        }

        private async Task SeedChatHistory()
        {
            if (_dbContext.ChatHistories.Any())
            {
                return;
            }

            var chatHistory = new ChatHistory();
            await _dbContext.AddAsync(chatHistory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
