using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.CustomExceptions;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Implementation
{
    public class MinerAppService : IMinerAppService
    {
        private IMinerRepository iMinerRepository;

        public MinerAppService(IMinerRepository iMinerRepository)
        {
            this.iMinerRepository = iMinerRepository;
        }

        public async Task<MinerEntity> GetAsync(Guid minerId)
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

        public async Task<Guid> InsertAsync(string name)
        {
            FaultyService.ThrowRandomException(5);

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

        public async Task LogOutAsync(Guid minerId)
        {
            var miner = await this.GetAsync(minerId);
            if (miner != null)
            {
                miner.IsLogged = false;
                await this.iMinerRepository.UpdateAsync(miner);
            }
           
        }

        public async Task<bool> SaveGoldInMinersPocketAsync(Guid minerId, int quantity)
        {
            FaultyService.ThrowRandomException(3);
            var miner = await this.GetAsync(minerId);
            if (miner != null)
            {
                if(miner.IsLogged)
                    return await this.iMinerRepository.SaveGoldAsync(minerId, quantity);
                throw new UnauthorizedException();
            }

            return false;
        }

        public async Task<bool> SignUpAsync(Guid minerId)
        {
            FaultyService.ThrowRandomException(2);

            var miner = await this.GetAsync(minerId);
            if (miner != null && !miner.IsLogged)
            {
                miner.IsLogged = true;
                return await this.iMinerRepository.UpdateAsync(miner);
            }
            return false;
          
        }
    }
}
