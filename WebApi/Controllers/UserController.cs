using Microsoft.AspNetCore.Mvc;
using WebApi.Clients;
using WebApi.Models.DataTransferObject;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;


        public UserController(UserService userService)
        {
            _userService = userService;
        }
      
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            return Ok (await _userService.GetUsers());
        }

        

        [HttpGet("{id}")]
        public async Task <IActionResult> GetUserId(int id)
        {
            return Ok (await _userService.GetUserId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto user)
        {
            var result = await _userService.Create(user);
            return Created(nameof(Create),result);
        }



    }



}
