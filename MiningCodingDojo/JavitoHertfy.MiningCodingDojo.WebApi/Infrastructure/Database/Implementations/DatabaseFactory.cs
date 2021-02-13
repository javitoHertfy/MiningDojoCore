using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations
{
    public class DatabaseFactory : IDatabaseFactory
    {       
       
        public IMinerDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<MinerDbContext>()
                   .UseInMemoryDatabase(databaseName: "MinerDb")
                   .Options;

            var result = new MinerDbContext(options);
            return result;
            
        }
    }
}
