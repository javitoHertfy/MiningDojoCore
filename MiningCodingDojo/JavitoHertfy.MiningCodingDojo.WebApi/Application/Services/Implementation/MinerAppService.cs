using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Implementation
{
    public class MinerAppService : IMinerAppService
    {
        private IMinerRepository iMinerRepository;

        public MinerAppService(IMinerRepository iMinerRepository)
        {
            this.iMinerRepository = iMinerRepository;
        }

        public async Task<MinerEntity> GetAsync(int minerId)
        {
            var miners = await this.iMinerRepository.GetAsync();
            var miner = miners.FirstOrDefault(x => x.Id == minerId);
            return miner;
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
                Handicap = 1,
                IsLogged = false,
            };

            var result = await this.iMinerRepository.InsertAsync(miner);
            return result;
        }

        public async Task<bool> SaveGoldInMinersPocket(int minerId, int quantity)
        {

            var miner = await this.GetAsync(minerId);
            if(miner != null)
            {               
                if(miner.IsLogged)
                    return await this.iMinerRepository.SaveGoldAsync(minerId, quantity);
                throw new System.Exception($"Miner {minerId} not logged");            }

            return false;
        }
    }
}
