using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts
{
    public interface IMinerDbContext
    {
        DbSet<Miner> Miners { get; set; }

    }
}
