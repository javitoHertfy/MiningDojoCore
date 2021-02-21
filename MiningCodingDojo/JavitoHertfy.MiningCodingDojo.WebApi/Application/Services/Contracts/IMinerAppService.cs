using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts
{
    public interface IMinerAppService
    {
        Task<IEnumerable<MinerEntity>> GetAsync();

        Task<MinerEntity> GetAsync(int miner);

        Task<int> InsertAsync(string name);
        Task<bool> SaveGoldInMinersPocket(int minerId, int quantity);
    }
}
