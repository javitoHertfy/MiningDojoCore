using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Repository.Implementations
{
    public class MinerRepository : IMinerRepository
    {
        private readonly IMinerDbContext iMinerDbContext;
        private readonly IMinerEntityMapper iMinerEntityMapper;

        public MinerRepository(IMinerDbContext iMinerDbContext, IMinerEntityMapper iMinerEntityMapper)
        {

            this.iMinerDbContext = iMinerDbContext;
            this.iMinerEntityMapper = iMinerEntityMapper;
        }

        public async Task<IEnumerable<MinerEntity>> GetAsync()
        {
            var miners = await this.iMinerDbContext.Miners.AsQueryable().ToListAsync();            

            var result = miners.Select(miner => this.iMinerEntityMapper.Convert(miner));
            return result;
        }
    }
}
