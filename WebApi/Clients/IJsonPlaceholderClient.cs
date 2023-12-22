using WebApi.Models.DataTransferObject;

namespace WebApi.Clients
{
    public interface IJsonPlaceholderClient
    {
        Task<string> Create(UserDto user);
        Task<JsonResult<UserDto>> GetUserById(int id);
        Task<List<UserDto>> GetUsers();
    }
}