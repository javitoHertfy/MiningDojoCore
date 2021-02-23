using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts
{
    public interface IGoldMineRepository
    {
        Task<bool> SubstractGold(int quantity);

        Task<bool> Initialize();

        Task<GoldMineEntity> GetGoldMine();

    }
}
