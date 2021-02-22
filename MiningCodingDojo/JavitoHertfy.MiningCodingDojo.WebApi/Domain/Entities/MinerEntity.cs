using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Domain.Entities
{
    public class MinerEntity
    {     
        public Guid Id { get; set; }     
        public string Name { get; set; }     
        public int Quantity { get; set; }
        public int Handicap { get; set; }
        public bool IsLogged { get; set; }
    }
}
