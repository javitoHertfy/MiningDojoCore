using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts
{
    public interface IMinerRepository
    {
        Task<IEnumerable<MinerEntity>> GetAsync();

        Task<Guid> InsertAsync(MinerEntity minerEntity);

        Task<bool> Initialize();

        Task<bool> SaveGoldAsync(Guid minerId, int quantity);

        Task<bool> UpdateAsync(MinerEntity minerEntity);
    }
}
