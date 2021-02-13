using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations
{
    public class MinerDbContext : DbContext, IMinerDbContext
    {
        public MinerDbContext()
        {

        }
        public MinerDbContext(DbContextOptions<MinerDbContext> iMinerDbOptions)
             : base(iMinerDbOptions)
        {            

        }

        public DbSet<Miner> Miners { get; set; }

        public async Task<int> SaveContextChangesAsync()
        {
           return await this.SaveChangesAsync();
        }
    }
}
