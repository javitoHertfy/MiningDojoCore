using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations
{
    public class MinerDbContext : DbContext, IMinerDbContext
    {
        public MinerDbContext(DbContextOptions<MinerDbContext> iPostDbOptions)
             : base(iPostDbOptions)
        {
           
        }

        public DbSet<Miner> Miners { get; set; }
    }
}
