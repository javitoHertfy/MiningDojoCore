using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts
{
    public interface IGoldMineEntityMapper
    {
         GoldMineEntity Convert(GoldMineDbEntity goldMine);
    }
}
