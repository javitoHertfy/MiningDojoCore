using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts
{
    public interface IGoldMineAppService
    {
        Task<bool> SignUp(int minerId);
        Task<int> Dig(int minerId);
    }
}
