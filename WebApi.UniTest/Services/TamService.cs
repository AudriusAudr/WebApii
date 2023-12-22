using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebApi.Exceptions;
using WebApi.Models.DataTransferObject;
using WebApi.Models.Entities;
using WebApi.Repositories;
using WebApi.Services;
using AutoFixture;
using AutoFixture.Xunit2;
using static System.Net.Mime.MediaTypeNames;

namespace WebApi.UniTest.Services
{
    public class TamService
    {
        private readonly Mock<ITemRepository> _testRepository;
        private readonly ITemService _itemService;
        private readonly IFixture _fixture;

        public TamService()
        {
            _testRepository = new Mock<ITemRepository>();
            _itemService = new TemService(_testRepository.Object);
            _fixture = new Fixture();
        }

        [Theory]
        [AutoData]
        public async Task Get_GivenValidId_ReturnsDto(int id)
        {
            //Arrange
            ItemEntities itemDto = new ItemEntities()
            {
                Id = id
            };

            _testRepository.Setup(m => m.GetItem(id)).ReturnsAsync(itemDto);

            // Act
            var result = await _itemService.Get(id);

            // Assert
            result.Should().NotBeNull();
      
        }

        [Theory]
        [AutoData]
        public async Task Get_GivenInvalidId_ThrowsItemNotFoundException(int id)
        {
            // Arrange
            _testRepository.Setup(m => m.GetItem(id)).ReturnsAsync((ItemEntities?)null);

            // Act Assert
            var exception = await Assert.ThrowsAsync<NotFoundException>(async () => await _itemService.Get(id));

            exception.Should().NotBeNull();
            exception.Message.Should().Be("Not found");
        }

        [Theory]
        [AutoData]
        public async Task CheckGetAll()
        {

            //Arrange
            _testRepository.Setup(m => m.GetAll()).ReturnsAsync(new List<ItemEntities>());


            // Act
            var result = await _itemService.GetAll();

            // Assert
            result.Should().NotBeNull();
        }


        [Theory]
        [AutoData]
        public async Task UpdateItemSuccess(ItemDto itemDto)
        {
            // Arrange
            _testRepository.Setup(m => m.Update(It.IsAny<ItemEntities>())).Returns(Task.CompletedTask);

            // Act
            await _itemService.Update(itemDto);

            // Assert
            _testRepository.Verify(m => m.Update(It.IsAny<ItemEntities>()), Times.Once);
        }

        [Fact]
        public async Task CreateItemSuccess()
        {
            // Arrange
            var itemDto = new ItemDto { Id = 1, Name = "Sample Item" };
            var testRepository = new Mock<ITemRepository>();
            testRepository.Setup(m => m.Create(It.IsAny<ItemEntities>())).Returns(Task.CompletedTask);

            var temService = new TemService(testRepository.Object);

            // Act
            await temService.Create(itemDto);

            // Assert
            testRepository.Verify(repo => repo.Create(It.IsAny<ItemEntities>()), Times.Once);
        }


        [Fact]
        public async Task DeleteItemSuccess()
        {
            // Arrange
            var itemDto = new ItemDto { Id = 1, Name = "Item to Delete" };
            var testRepository = new Mock<ITemRepository>();
            testRepository.Setup(m => m.Delete(It.IsAny<ItemEntities>())).Returns(Task.CompletedTask);

            var temService = new TemService(testRepository.Object);

            // Act
            await temService.Delete(itemDto);

            // Assert
            testRepository.Verify(repo => repo.Delete(It.IsAny<ItemEntities>()), Times.Once);
        }



        








    }
}



//[Fact]
//public async Task DeleteCheck()
//{

//    int id = 1;
//    var testRepository = new Mock<ITemRepository>();
//    testRepository.Setup(m => m.DeleteAsync()(new WebApi.Models.Entities.ItemEntities()));


//    var temServices = new TemService(testRepository.Object);
//    var result = await temServices.Delete();

//    result.Should();
//}

//[Fact]
//public async Task UpdateCheck()
//{


//    var testRepository = new Mock<ITemRepository>();
//    testRepository.Setup(m => m.Update()).ReturnsAsync(new ItemEntities());

//    var todoService = new TemService(testRepository.Object);
//    var result = await todoService.Update();

//    result.Should();
//}
