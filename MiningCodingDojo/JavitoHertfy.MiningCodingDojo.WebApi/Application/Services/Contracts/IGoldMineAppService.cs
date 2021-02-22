using System;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts
{
    public interface IGoldMineAppService
    {
        Task<bool> SignUp(Guid minerId);
        Task<int> Dig(Guid minerId);
    }
}
