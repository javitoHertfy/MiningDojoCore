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
                
                context.Miners.AddRange(
                  new Database.DbEntities.MinerDbEntity
                  {
                      Id = new Guid("0b361510-6f7b-43fb-99eb-f7c4b188f10a"),
                      Name = "Javito Hertfy",
                      Quantity = 0,
                      Handicap = 1
                  });

                return await context.SaveContextChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Guid> InsertAsync(MinerEntity minerEntity)
        {
            try
            {
                MinerDbEntity miner = new MinerDbEntity();
                using var context = this.iDatabaseFactory.GetDbContext();
                ////Determine the next ID
                var newID = Guid.NewGuid();
                miner.Id = newID;
                miner.Name = minerEntity.Name;
                miner.Quantity = minerEntity.Quantity;
                miner.Handicap = minerEntity.Handicap;

                context.Miners.Add(miner);
                var isInserted = await context.SaveContextChangesAsync() > 0;
                if (isInserted)
                {
                    var result = miner.Id;
                    return result;
                }
                throw new Exception("Miner Not Inserted");
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        public async Task<bool> SaveGoldAsync(Guid minerId, int quantity)
        {
            try
            {
                using var context = this.iDatabaseFactory.GetDbContext();
                ////Determine the next ID
                var miner = context.Miners.FirstOrDefault(x => x.Id == minerId);
                if(miner != null)
                {
                    miner.Quantity += quantity;
                    return await context.SaveContextChangesAsync() > 0;
                }               
                
            }
            catch (Exception ex)
            {
                throw;
            }

            return false;

        }

        public async Task<bool> UpdateAsync(MinerEntity minerEntity)
        {
            try
            {                
                using var context = this.iDatabaseFactory.GetDbContext();
                var miner = context.Miners.FirstOrDefault(x=> x.Id == minerEntity.Id);
                if(miner != null)
                {
                    miner.Handicap = minerEntity.Handicap;
                    miner.Name = minerEntity.Name;
                    miner.Quantity = minerEntity.Quantity;
                    miner.IsLogged = minerEntity.IsLogged;
                    int result = await context.SaveContextChangesAsync();

                    return result > 0;

                }
                return false;
                         
               
            }
            catch (Exception)
            {
                throw;
            };
        }
    }
}
