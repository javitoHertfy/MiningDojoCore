using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts
{
    public interface IGoldMineRepository
    {
        Task<bool>SignUp(int miner);

        Task<bool> SubstractGold(int quantity);

        Task<bool> LogOut(int minerId);

        Task<bool> Initialize();

    }
}
