using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DataTransferObject;
using WebApi.Models.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;


        public ShopController(ShopService shopService)
        {
              _shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> AllShop() 
        {
            return Ok(await _shopService.AllShop());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShopDto Item)
        {
            await _shopService.Create(Item);
            return Ok();
        }

    }
}
