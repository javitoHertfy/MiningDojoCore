using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

                context.GoldMine.Add(new GoldMineDbEntity()
                {
                    Id = 0,
                    GoldLeft = 10000000,
                    MinersLogged = JsonSerializer.Serialize(new List<int>())

                });
                context.Miners.AddRange(
                  new Database.DbEntities.MinerDbEntity
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

        public async Task<int> InsertAsync(MinerEntity minerEntity)
        {
            try
            {
                MinerDbEntity miner = new MinerDbEntity();
                using var context = this.iDatabaseFactory.GetDbContext();
                ////Determine the next ID
                var newID = context.Miners.Select(x => x.Id).Max() + 1;
                miner.Id = newID;
                miner.Name = minerEntity.Name;
                miner.Quantity = minerEntity.Quantity;

                context.Miners.Add(miner);
                await context.SaveContextChangesAsync();
                var result = miner.Id;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
