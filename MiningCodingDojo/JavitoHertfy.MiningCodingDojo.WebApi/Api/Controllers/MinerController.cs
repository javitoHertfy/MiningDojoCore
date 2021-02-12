using JavitoHertfy.MiningCodingDojo.WebApi.Api.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MinerController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<MinerResponse> Get()
        {
            return new List<MinerResponse>()
            {
                new MinerResponse()
                {
                    Id= 1,
                    Name = "Javi",
                    Quantity = 100

                }
            };
          
        }

    }
}
