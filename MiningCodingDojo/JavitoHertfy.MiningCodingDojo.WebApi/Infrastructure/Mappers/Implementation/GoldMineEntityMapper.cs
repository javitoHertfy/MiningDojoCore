using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Implementation
{
    public class GoldMineEntityMapper : IGoldMineEntityMapper
    {
        public GoldMineEntity Convert(GoldMineDbEntity goldMine)
        {
            return new GoldMineEntity()
            {
                Difficulty = 0,
                GoldLeft = goldMine.GoldLeft,
                MinersLogged = JsonSerializer.Deserialize<List<Guid>>(goldMine.MinersLogged)
            };
        }
    }
}
