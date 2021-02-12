using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Implementation
{
    public class MinerEntityMapper : IMinerEntityMapper
    {
        public MinerEntity Convert(Miner miner)
        {
           return new MinerEntity()
           {
                Id = miner.Id,
                Handicap = miner.Handicap,
                Name = miner.Name,
                Quantity = miner.Quantity
                
           };
        }
    }
}
