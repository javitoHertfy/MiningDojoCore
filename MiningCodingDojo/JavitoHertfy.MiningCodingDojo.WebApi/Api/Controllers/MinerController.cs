using JavitoHertfy.MiningCodingDojo.WebApi.Api.Model.Response;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.DbEntities;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinerController : ControllerBase
    {
        private MinerDbContext context;

        public MinerController(MinerDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public Task<IActionResult> Get()
        {
            var miners = this.context.Miners;
            return Task.FromResult<IActionResult>(Ok(miners));

        }

        [HttpPost]
        public Task<IActionResult> Post(Miner miner)
        {
            //Determine the next ID
            var newID = context.Miners.Select(x => x.Id).Max() + 1;
            miner.Id = newID;
            miner.Name = $"Miner_{newID}";
            miner.Quantity = 0;

            context.Miners.Add(miner);
            context.SaveChanges();
         

            return Task.FromResult<IActionResult>(Ok());
        }

    }
}
