using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Clients;
using WebApi.Exceptions;
using WebApi.Models.DataTransferObject;
using WebApi.Repositories;

namespace WebApi.Services
{
    public class UserService
    {
        private readonly IJsonPlaceholderClient _client;

        

        public UserService(IJsonPlaceholderClient client)
        {
            _client = client;
        }

        public async Task<JsonResult<UserDto>> GetUserId(int id)
        {


            return await _client.GetUserById(id);

        }

        public async Task<List<UserDto>> GetUsers()
        {

            return await _client.GetUsers();
        }
        public async Task<string> Create(UserDto user)
        {
            return await _client.Create(user);
        }




    }
}



