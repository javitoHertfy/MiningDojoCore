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
       

        [HttpPut]
        [Route("Dig/{minerId}")]
        public async Task<IActionResult> Dig(Guid minerId)
        {
            var goldSubstracted = await this.iGoldMineAppService.Dig(minerId);           
            return Ok(goldSubstracted);
        }

    }
}
