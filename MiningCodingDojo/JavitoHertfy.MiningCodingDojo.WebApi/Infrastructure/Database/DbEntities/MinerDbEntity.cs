using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities
{
    public partial class MinerDbEntity
    {
        public MinerDbEntity()
        {
           
        }

        [Key]
        public int Id { get; set; }    
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]        
        public int Quantity { get; set; }

               
        public int Handicap { get; set; }
    }
}
