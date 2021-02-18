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
        [Route("SignUp/{id}")]
        public async Task<IActionResult> SignUp(int id)
        {
            var miners = await this.iGoldMineAppService.SignUp(id);
            return Ok(miners);
        }

        [HttpPut]
        [Route("Dig/{id}")]
        public async Task<IActionResult> Dig(int id)
        {
            var miners = await this.iGoldMineAppService.Dig(id);
            return Ok(miners);
        }

    }
}
