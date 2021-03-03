using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts
{
    public interface IGoldMineAppService
    {
        Task<GoldMineEntity> GetAsync();
        Task<int> Dig(Guid minerId);
    }
}
