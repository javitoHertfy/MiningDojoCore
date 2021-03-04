using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services
{
    public static class LedgerChecker
    {
        public static Dictionary<Guid, int> LastQuantityOfGoldDiggedByMiner { get; set; }

        public static bool IsQuantityDiggedCorrect(Guid miner, int goldMined)
        {
            if(LastQuantityOfGoldDiggedByMiner[miner] == goldMined)
                return true;
            return false;
        }

    }
}
