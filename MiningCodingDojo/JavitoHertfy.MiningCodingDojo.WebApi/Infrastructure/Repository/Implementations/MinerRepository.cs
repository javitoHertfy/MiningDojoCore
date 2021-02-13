using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Repository.Implementations
{
    public class MinerRepository : IMinerRepository
    {
        private readonly IDatabaseFactory iDatabaseFactory;
        private readonly IMinerEntityMapper iMinerEntityMapper;

        public MinerRepository(IDatabaseFactory iDatabaseFactory, IMinerEntityMapper iMinerEntityMapper)
        {

            this.iDatabaseFactory = iDatabaseFactory;
            this.iMinerEntityMapper = iMinerEntityMapper;
        }

        public async Task<IEnumerable<MinerEntity>> GetAsync()
        {
            using var context = this.iDatabaseFactory.GetDbContext();

            var miners = await context.Miners.AsQueryable().ToListAsync();            

            var result = miners.Select(miner => this.iMinerEntityMapper.Convert(miner));
            return result;
        }

        public async Task<bool> Initialize()
        {
            try
            {
                using var context = this.iDatabaseFactory.GetDbContext();

                context.Miners.AddRange(
                  new Database.DbEntities.Miner
                  {
                      Id = 0,
                      Name = "Javito Hertfy",
                      Quantity = 0,
                      Handicap = 0
                  });

                return await context.SaveContextChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public Task<MinerEntity> Insert(MinerEntity minerEntity)
        {
            throw new NotImplementedException();
        }
    }
}
