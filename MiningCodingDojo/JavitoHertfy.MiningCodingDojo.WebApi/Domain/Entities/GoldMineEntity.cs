using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities
{
    public class GoldMineEntity
    {
        public int GoldLeft { get; set; }
        public int Difficulty { get; set; }
        public List<Guid> MinersLogged { get; set; }
    }
}
