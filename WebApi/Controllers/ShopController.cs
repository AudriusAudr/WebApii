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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _shopService.Get(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shopService.Delete(id);
            return Ok();
        }

        [HttpPost("{ShopId}/{ItemId}")]
        public async Task<IActionResult>PutItemToShop(int shopId, int itemId)
        {
            await _shopService.PutItemToShop(shopId, itemId);
            return Ok();
        }


    }
}
