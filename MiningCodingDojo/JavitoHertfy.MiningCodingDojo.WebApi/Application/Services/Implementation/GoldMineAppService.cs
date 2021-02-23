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

                    throw new System.Exception($"Miner {minerId} not logged");
                    var random = new Random();
                    quantity = random.Next(10) / miner.Handicap;

                    await iGoldMineRepository.SubstractGold(quantity);
                    await iMinerAppService.SaveGoldInMinersPocket(minerId, quantity);
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
