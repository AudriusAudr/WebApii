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

        {

            {
            //Arrange
            ItemEntities itemDto = new ItemEntities()
            {
                Id = id


            // Act

            // Assert
        }

        {
            // Arrange

            var todoService = new TemService(testRepository.Object);

            // Act Assert
        }

        public async Task CheckGetAll()
        {

            //Arrange


            // Act

            var result = await temServices.GetAll();
            // Assert
            result.Should().NotBeNull();
        }


        {
            // Arrange

            // Act

            // Assert
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
            // Check if the repository's Create method was called with the expected parameters
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
