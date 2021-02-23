using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Implementation
{
    public class GoldMineEntityMapper : IGoldMineEntityMapper
    {
        public async Task<GoldMineEntity> Convert(GoldMineDbEntity goldMine)
        {
            return await Task.FromResult(new GoldMineEntity()
            {
                Difficulty = 0,
                GoldLeft = goldMine.GoldLeft,
            });
        }
    }
}
