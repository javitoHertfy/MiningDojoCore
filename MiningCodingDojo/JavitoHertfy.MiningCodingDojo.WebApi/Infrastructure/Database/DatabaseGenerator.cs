using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MinerDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MinerDbContext>>()))
            {
                // Look for any board games.
                if (context.Miners.Any())
                {
                    return;   // Data was already seeded
                }

                context.Miners.AddRange(
                    new DbEntities.Miner
                    {
                       Id = 0,
                       Name = "Javito Hertfy",
                       Quantity = 0,
                       Handicap = 0
                    });

                context.SaveChanges();
            }
        }
    }
}
