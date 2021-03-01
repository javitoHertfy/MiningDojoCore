using System;
using System.ComponentModel.DataAnnotations;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities
{
    public partial class MinerDbEntity
    {
        public MinerDbEntity()
        {
           
        }

        [Key]
        public Guid Id { get; set; }    
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]        
        public int Quantity { get; set; }

               
        public int Handicap { get; set; }

        public bool IsLogged { get; set; }
    }
}
