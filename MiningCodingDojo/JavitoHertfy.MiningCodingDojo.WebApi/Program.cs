using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var iConfigurationRoot = new ConfigurationBuilder()
              .AddEnvironmentVariables()
              .AddUserSecrets<Program>(true)
              .Build();

            var host = CreateHostBuilder(args, iConfigurationRoot).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;              

                DataGenerator.Initialize(services);
            }

            LedgerChecker.LastQuantityOfGoldDiggedByMiner = new Dictionary<Guid, int>();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot iConfiguration) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((context, builder) =>
                 {
                     builder.AddConfiguration(iConfiguration);                     
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                })
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                    options.ValidateOnBuild = true;
                });
    }
}
