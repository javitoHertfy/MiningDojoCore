using System;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts
{
    public interface IGoldMineRepository
    {
        Task<bool>SignUp(Guid miner);

        Task<bool> SubstractGold(int quantity);

        Task<bool> LogOut(Guid minerId);

        Task<bool> Initialize();

    }
}
