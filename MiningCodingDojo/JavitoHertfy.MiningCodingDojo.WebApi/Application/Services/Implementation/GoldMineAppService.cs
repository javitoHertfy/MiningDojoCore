using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Implementation
{
    public class GoldMineAppService : IGoldMineAppService
    {
        
        public GoldMineAppService()
        {

        }
        public Task<int> Dig(int minerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SignUp(int minerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
