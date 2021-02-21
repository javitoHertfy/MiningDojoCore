using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using System;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Repository.Implementations
{
    public class GoldMineRepository : IGoldMineRepository
    {
        private readonly IDatabaseFactory iDatabaseFactory;
        private readonly IGoldMineEntityMapper iGoldMineEntityMapper;

        public GoldMineRepository(IDatabaseFactory iDatabaseFactory, IGoldMineEntityMapper iGoldMineEntityMapper)
        {

            this.iDatabaseFactory = iDatabaseFactory;
            this.iGoldMineEntityMapper = iGoldMineEntityMapper;
        }

        public async Task<bool> SignUp(int miner)
        {
            using var context = this.iDatabaseFactory.GetDbContext();
            var goldMine = context.GoldMine.FirstOrDefault();
            var minersLoggedList = JsonSerializer.Deserialize<List<int>>(goldMine.MinersLogged);
            if (!minersLoggedList.Any(x=> x == miner))
            {
                minersLoggedList.Add(miner);
                goldMine.MinersLogged = JsonSerializer.Serialize(minersLoggedList);
            }
            else
            {
                throw new System.Exception("Already logged");
            }
            context.GoldMine.Update(goldMine);
            await context.SaveContextChangesAsync();
            return true;
        }

        public async Task<bool> LogOut(int minerId)
        {
            using var context = this.iDatabaseFactory.GetDbContext();
            var goldMine = context.GoldMine.FirstOrDefault();
            var result = goldMine.MinersLogged.Remove(minerId);

            context.GoldMine.Update(goldMine);

            await context.SaveContextChangesAsync();
            return true;
        }

        public async Task<bool> SubstractGold(int quantity)
        {
            using var context = this.iDatabaseFactory.GetDbContext();
            var goldMine = context.GoldMine.FirstOrDefault();
            if(goldMine.GoldLeft > 0)
            {
                goldMine.GoldLeft -= quantity;
                context.GoldMine.Update(goldMine);
                await context.SaveContextChangesAsync();
                return true;
            }
            throw new System.Exception("No more Gold in the mine");
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

                return await context.SaveContextChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
