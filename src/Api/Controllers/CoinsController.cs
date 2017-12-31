using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CoinsController : Controller
    {
        private readonly ICoinsService _service;
        public CoinsController(ICoinsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllCoins());
        }

        [HttpGet("{convert}")]
        public string Get(string convert)
        {
            return "value";
        }
    }
}
