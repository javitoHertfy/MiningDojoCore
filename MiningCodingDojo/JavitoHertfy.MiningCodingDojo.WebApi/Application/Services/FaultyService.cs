using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Services
{
    public static class FaultyService
    {
        public static void ThrowRandomException(int probability)
        {
            Random random = new Random();
            var faultyNumber = random.Next(0, probability);
            if(faultyNumber == 1)
            {
                throw new Exception("The API is down, sorry :(");
            }
        }
    }
}
