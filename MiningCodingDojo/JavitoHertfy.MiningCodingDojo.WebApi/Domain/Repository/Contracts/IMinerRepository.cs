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

        Task<int> InsertAsync(MinerEntity minerEntity);

        Task<bool> Initialize();

        Task<bool> SaveGoldAsync(int minerId, int quantity);
    }
}
