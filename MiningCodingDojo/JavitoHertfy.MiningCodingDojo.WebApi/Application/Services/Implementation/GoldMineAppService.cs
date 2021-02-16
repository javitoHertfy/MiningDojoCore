using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Implementation
{
    public class GoldMineAppService : IGoldMineAppService
    {
        private IGoldMineRepository iGoldMineRepository;
        
        public GoldMineAppService(IGoldMineRepository iGoldMineRepository)
        {
            this.iGoldMineRepository = iGoldMineRepository;

        }
        public Task<int> Dig(int minerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SignUp(int minerId)
        {
            iGoldMineRepository.;
        }
    }
}
