using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using System;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Implementation
{
    public class GoldMineAppService : IGoldMineAppService
    {
        private IGoldMineRepository iGoldMineRepository;
        private IMinerAppService iMinerAppService;

        public GoldMineAppService(IGoldMineRepository iGoldMineRepository, IMinerAppService iMinerAppService)
        {
            this.iGoldMineRepository = iGoldMineRepository;
            this.iMinerAppService = iMinerAppService;

        }
        public async Task<int> Dig(Guid minerId)
        {
            int quantity = 0;
            try
            {
                var miner = await this.iMinerAppService.GetAsync(minerId);

                if (miner != null)
                {                
                    if(miner.IsLogged)
                    {
                        var random = new Random();
                        quantity = random.Next(10) / miner.Handicap;

                        await iGoldMineRepository.SubstractGold(quantity);
                        await iMinerAppService.SaveGoldInMinersPocket(minerId, quantity);
                    }
                    throw new Exception("Miner not logged please sign up first");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return quantity;
        }

       
    }
}
