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

        Task<MinerEntity> GetAsync(Guid miner);

        Task<Guid> InsertAsync(string name);

        Task<bool> SignUp(Guid miner);

        Task<bool> SaveGoldInMinersPocket(Guid minerId, int quantity);
    }
}
