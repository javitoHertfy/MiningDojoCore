using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.CustomExceptions;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var miners = await this.iGoldMineAppService.GetAsync();
            return Ok(miners);

        }

        [HttpPut]
        [Route("Dig/{minerId}")]
        public async Task<IActionResult> Dig(Guid minerId)
        {
            try
            {
                var goldSubstracted = await this.iGoldMineAppService.Dig(minerId);
                return Ok(goldSubstracted);
            }
            catch (ServiceUnavailableException)
            {
                return StatusCode(503);
            }        
            catch(UnauthorizedException)
            {
                return StatusCode(401);
            }
            
        }

    }
}
