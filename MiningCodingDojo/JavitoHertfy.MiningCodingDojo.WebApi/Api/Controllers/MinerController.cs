using JavitoHertfy.MiningCodingDojo.WebApi.Api.Model.Request;
using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinerController : Controller
    {        
        private IMinerAppService iMinerAppService;

        public MinerController(IMinerAppService iMinerAppService)
        {
            this.iMinerAppService = iMinerAppService;           
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var miners = await this.iMinerAppService.GetAsync();
            return Ok(miners);

        }

        [HttpGet("{minerId}")]
        public async Task<IActionResult> Get(Guid minerId)
        {
            var miner = await this.iMinerAppService.GetAsync(minerId);
            return Ok(miner);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MinerRequest minerRequest)
        {
           
            var minerId  = await this.iMinerAppService.InsertAsync(minerRequest.Name);
            return Ok(minerId);
        }

        [HttpPost]
        [Route("SignUp/{minerId}")]
        public async Task<IActionResult> SignUp(Guid minerId)
        {
            var miners = await this.iMinerAppService.SignUp(minerId);
            return Ok(miners);
        }
    }
}
