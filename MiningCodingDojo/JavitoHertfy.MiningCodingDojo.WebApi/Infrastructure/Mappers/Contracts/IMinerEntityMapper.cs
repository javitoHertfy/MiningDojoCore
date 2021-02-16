using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts
{
    public interface IMinerEntityMapper
    {
        public MinerEntity Convert(MinerDbEntity miner);
    }
}
