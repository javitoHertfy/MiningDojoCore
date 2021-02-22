using System.ComponentModel.DataAnnotations;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities
{
    public partial class GoldMineDbEntity
    {
        public GoldMineDbEntity()
        {
           
        }

        [Key]
        public int Id { get; set; }

        public int GoldLeft { get; set; }   

        public string MinersLogged { get; set; }
        
    }
}
