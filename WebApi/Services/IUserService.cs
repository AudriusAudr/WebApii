using WebApi.Clients;
using WebApi.Models.DataTransferObject;

namespace WebApi.Services
{
    public interface IUserService
    {
        Task<string> Create(UserDto user);
        Task<JsonResult<UserDto>> GetUserId(int id);
        Task<List<UserDto>> GetUsers();
    }
}