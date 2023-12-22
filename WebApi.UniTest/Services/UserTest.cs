using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Clients;
using WebApi.Models.DataTransferObject;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.UniTest.Services
{
    public class UserTest
    {
        private readonly Mock<IJsonPlaceholderClient> _jsonPlaceholderClient;
        private readonly UserService _userService;
        private readonly IFixture _fixture;

        public UserTest()
        {
            _jsonPlaceholderClient = new Mock<IJsonPlaceholderClient>();
            _userService = new UserService(_jsonPlaceholderClient.Object);
            _fixture = new Fixture();
        }

        [Theory]
        [AutoData]
        public async Task Get_User_ID(int id)
        {
            ItemDto itemDto = new ItemDto()
            {
                Id = id
            };

            
        }


    }
}
