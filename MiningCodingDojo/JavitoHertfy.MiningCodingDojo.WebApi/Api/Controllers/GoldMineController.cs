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
    public class GoldMineController : Controller
    {
        private IGoldMineAppService iGoldMineAppService;

        public GoldMineController(IGoldMineAppService iGoldMineAppService)
        {
            this.iGoldMineAppService = iGoldMineAppService;
        }
        
        [HttpPost]
        [Route("SignUp/{minerId}")]
        public async Task<IActionResult> SignUp(int minerId)
        {
            var miners = await this.iGoldMineAppService.SignUp(minerId);
            return Ok(miners);
        }

        [HttpPut]
        [Route("Dig/{minerId}")]
        public async Task<IActionResult> Dig(int minerId)
        {
            var goldSubstracted = await this.iGoldMineAppService.Dig(minerId);           
            return Ok(goldSubstracted);
        }

    }
}
