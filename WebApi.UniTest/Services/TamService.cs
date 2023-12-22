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

namespace WebApi.UniTest.Services
{
    public class TamService
    {

        [Fact]
        public async Task Get_GivenValidId_ReturnsDto()
        {
            //Arrange
            int id = 1;

            var testRepository = new Mock<ITemRepository>();
            testRepository.Setup(m => m.GetItem(id)).ReturnsAsync(new WebApi.Models.Entities.ItemEntities()
            {
                Id = id
            });

            var todoService = new TemService(testRepository.Object);

            // Act
            var result = await todoService.Get(id);

            // Assert
            result.Id.Should().Be(id);
        }

        [Fact]
        public async Task Get_GivenInvalidId_ThrowsItemNotFoundException()
        {
            // Arrange
            int id = 1;
            var testRepository = new Mock<ITemRepository>();
            testRepository.Setup(m => m.GetItem(id)).Returns(Task.FromResult<ItemEntities>(null));

            var todoService = new TemService(testRepository.Object);

            // Act Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await todoService.Get(id));
        }




        [Fact]
        public async Task CheckGetAll()
        {

            //Arrange
            var testRepository = new Mock<ITemRepository>();
            testRepository.Setup(m => m.GetAll()).ReturnsAsync(new List<ItemEntities>()
            {
                new ItemEntities() { Id = 1, Name = "Item1", Price = 10.0m },
            });

            // Act
            var temServices = new TemService(testRepository.Object);

            var result = await temServices.GetAll();
            // Assert
            result.Should().NotBeNull();
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

        [Fact]
        public async Task UpdateItemSuccess()
        {
            // Arrange
            var itemDto = new ItemDto { Id = 1, Name = "Updated Item" };
            var testRepository = new Mock<ITemRepository>();
            testRepository.Setup(m => m.Update(It.IsAny<ItemEntities>())).Returns(Task.CompletedTask);

            var temService = new TemService(testRepository.Object);

            // Act
            await temService.Update(itemDto);

            // Assert
            testRepository.Verify(repo => repo.Update(It.IsAny<ItemEntities>()), Times.Once);
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


