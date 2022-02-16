using BugTrackerTry.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fine
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //Pull out my registered DataService
            var dataService = host.Services
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<DataService>();


            //var dbContext = host.Services
            //                    .CreateScope().ServiceProvider
            //                    .GetRequiredService<ApplicationDbContext>();

            await dataService.ManageDataAsync();
            //await dbContext.Database.MigrateAsync();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
