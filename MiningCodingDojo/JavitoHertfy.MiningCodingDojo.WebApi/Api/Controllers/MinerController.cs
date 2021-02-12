using JavitoHertfy.MiningCodingDojo.WebApi.Api.Model.Request;
using JavitoHertfy.MiningCodingDojo.WebApi.Api.Model.Response;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
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
        private IMinerRepository iMinerRepository;

        public MinerController(IMinerRepository iMinerRepository, MinerDbContext context)
        {
            this.iMinerRepository = iMinerRepository;
            this.context = context; 
        }
        [HttpGet]
        public Task<IActionResult> Get()
        {
            var miners = iMinerRepository.GetAsync();
            return Task.FromResult<IActionResult>(Ok(miners));

        }

        [HttpPost]
        public Task<IActionResult> Post(MinerRequest minerRequest)
        {
            var miner = new Miner();
            //Determine the next ID
            var newID = context.Miners.Select(x => x.Id).Max() + 1;
            miner.Id = newID;
            miner.Name = minerRequest.Name;
            miner.Quantity = 0;

            context.Miners.Add(miner);
            context.SaveChanges();
         

            return Task.FromResult<IActionResult>(Ok(miner));
        }

    }
}
