using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.Controllers
{
    public class GoldMineController: ControllerBase
    {
        private IGoldMineAppService iGoldMineAppService;

        public GoldMineController(IGoldMineAppService iGoldMineAppService)
        {
            this.iGoldMineAppService = iGoldMineAppService;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromRoute] int minerId)
        {
            var miners = await this.iGoldMineAppService.SignUp(minerId);
            return Ok(miners);
        }

    }
}
