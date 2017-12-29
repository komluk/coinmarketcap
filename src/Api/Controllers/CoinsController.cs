using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Services;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CoinsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.coinmarketcap.com");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var service = new CoinsService(client);
                var result = await service.GetAllCoins();
                return Ok(result);
            }
        }

        [HttpGet("{convert}")]
        public string Get(string convert)
        {
            return "value";
        }
    }
}
