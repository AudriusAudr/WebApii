using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Entities;
using WebApi.Services;
using WebApi.Models.DataTransferObject;
using Microsoft.AspNetCore.Http.Connections;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly TemService _itemService;
        public ItemController(TemService itemService)
        {
            _itemService = itemService;
        }


        [HttpPost]
        public async Task< IActionResult> Index([FromBody] ItemDto Item)
        {
            await _itemService.Create(Item);
            return Created();
        }

        [HttpGet]
        public async Task < IActionResult> Get()
        {

            return Ok(await _itemService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task< IActionResult> GetItem(int id)
        {
            return Ok(await _itemService.Get(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ItemDto item)
        {
            await _itemService.Update(item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] ItemDto item)
        {

            await _itemService.Delete(item);
            return Ok();


            //        }


            //        [HttpGet("{id}/buy")]
            //        public IActionResult Buy(int id, [FromQuery] int quantity) 
            //        {
            //            return Ok(_itemService.BuyItem(id, quantity));
            //       









    }   }
}
