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
            var miner = await this.iMinerAppService.GetAsync(minerId);

            var random = new Random();
            int quantity = random.Next(10) / miner.Handicap;

            try
            {
                await iGoldMineRepository.SubstractGold(quantity);
                await iMinerAppService.SaveGoldInMinersPocket(minerId, quantity);
            }
            catch(Exception)
            {
                throw;
            }           

            return quantity;
        }

        public async Task<bool> SignUp(Guid minerId)
        {
            
            return await iGoldMineRepository.SignUp(minerId);
        }
    }
}
