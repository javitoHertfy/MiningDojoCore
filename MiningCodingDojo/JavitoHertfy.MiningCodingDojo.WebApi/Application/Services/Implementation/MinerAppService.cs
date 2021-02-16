using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Implementation
{
    public class MinerAppService : IMinerAppService
    {
        private IMinerRepository iMinerRepository;

        public MinerAppService(IMinerRepository iMinerRepository)
        {
            this.iMinerRepository = iMinerRepository;
        }


        public async Task<IEnumerable<MinerEntity>> GetAsync()
        {
            var miners = await this.iMinerRepository.GetAsync();
            return miners;
        }

        public async Task<int> InsertAsync(string name)
        {
            MinerEntity miner = new MinerEntity()
            {
                Name = name,
                Quantity = 0,
                Handicap = 0,
                IsLogged = false,
            };

            var result = await this.iMinerRepository.InsertAsync(miner);
            return result;
        }

        public Task<bool> SaveGoldInMinersPocket(int minerId, int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}
