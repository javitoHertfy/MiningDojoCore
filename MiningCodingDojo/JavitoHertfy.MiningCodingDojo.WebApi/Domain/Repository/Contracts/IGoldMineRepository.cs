using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts
{
    public interface IGoldMineRepository
    {
        Task<bool >SignUp(int miner);
    }
}
