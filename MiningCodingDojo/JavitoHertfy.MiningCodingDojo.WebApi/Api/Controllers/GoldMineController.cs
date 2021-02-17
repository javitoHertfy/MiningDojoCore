using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoldMineController : ControllerBase
    {
        private IGoldMineAppService iGoldMineAppService;

        public GoldMineController(IGoldMineAppService iGoldMineAppService)
        {
            this.iGoldMineAppService = iGoldMineAppService;
        }
        
        [HttpGet("{minerId}", Name = "SignUp")]
        public async Task<IActionResult> SignUp([FromRoute] int minerId)
        {
            var miners = await this.iGoldMineAppService.SignUp(minerId);
            return Ok(miners);
        }

        [HttpPut]
        public async Task<IActionResult> Dig([FromRoute] int minerId)
        {
            var miners = await this.iGoldMineAppService.Dig(minerId);
            return Ok(miners);
        }

    }
}
