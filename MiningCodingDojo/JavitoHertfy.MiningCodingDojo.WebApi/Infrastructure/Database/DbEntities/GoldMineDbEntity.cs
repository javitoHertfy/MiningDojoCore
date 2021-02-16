using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities
{
    public partial class GoldMineDbEntity
    {
        public GoldMineDbEntity()
        {
           
        }
        
        public int QuantityLeft { get; set; }   

        public List<int> MinersLogged { get; set; }
        
    }
}
