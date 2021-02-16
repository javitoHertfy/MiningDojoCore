using System.Collections.Generic;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities
{
    public partial class GoldMineDbEntity
    {
        public GoldMineDbEntity()
        {
           
        }
        
        public int GoldLeft { get; set; }   

        public List<int> MinersLogged { get; set; }
        
    }
}
