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

        Task<bool> SignUpAsync(Guid miner);

        Task<bool> SaveGoldInMinersPocketAsync(Guid minerId, int quantity);
        Task LogOutAsync(Guid id);
    }
}
