using JavitoHertfy.MiningCodingDojo.WebApi.Api.Model.Request;
using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Domain.CustomExceptions;
using Microsoft.AspNetCore.Http;
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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MinerRequest minerRequest)
        {
            try
            {
                var minerId = await this.iMinerAppService.InsertAsync(minerRequest.Name);
                return Ok(minerId);

            }
            catch (ServiceUnavailableException)
            {
                return StatusCode(503);
            }
            catch (UnauthorizedException)
            {
                return StatusCode(401);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPut]
        [Route("SignUp/{minerId}")]
        public async Task<IActionResult> SignUp(Guid minerId)
        {
            try
            {
                var miners = await this.iMinerAppService.SignUpAsync(minerId);
                return Ok(miners);
            }
            catch (ServiceUnavailableException)
            {
                return StatusCode(503);
            }
            catch (UnauthorizedException)
            {
                return StatusCode(401);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPut]
        [Route("SaveGold/{minerId}")]
        public async Task<IActionResult> SaveGold(Guid minerId, int quantity)
        {
            try
            {
                var miners = await this.iMinerAppService.SaveGoldInMinersPocketAsync(minerId, quantity);
                return Ok(miners);
            }
            catch (ServiceUnavailableException)
            {
                return StatusCode(503);
            }
            catch (UnauthorizedException)
            {
                return StatusCode(401);
            }
        }
    }
}
