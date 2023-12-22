using WebApi.Models.DataTransferObject;
using WebApi.Models.Entities;
using WebApi.Repositories;
using System.Reflection.Metadata.Ecma335;
using WebApi.Exceptions;

namespace WebApi.Services
{
    public class TemService : ITemService
    {
        private readonly ITemRepository _temRepository;
        public TemService(ITemRepository temRepository)
        {
            _temRepository = temRepository;
        }

        public async Task Create(ItemDto itemDto)
        {
            var entity = new ItemEntities
            {
                Id = itemDto.Id,
                Name = itemDto.Name
            };
            await _temRepository.Create(entity);
        }


        public async Task<List<ItemDto>> GetAll()
        {
            List<ItemDto> itemDto1 = new();
            var Item = await _temRepository.GetAll();
            var itemDto = Item.Select(t => new ItemDto
            {
                Id = t.Id,
                Name = t.Name,
            }).ToList();
            return itemDto;

        }
        public async Task<ItemDto> Get(int id)
        {


            var entity = await _temRepository.GetItem(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            return new ItemDto { Id = entity.Id, Name = entity.Name };

        }

        public async Task Update(ItemDto item)
        {
            try
            {

                var itemE = new ItemEntities
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                await _temRepository.Update(itemE);

            }
            catch (SqlException ex)
            {
                throw new SqlException("Update" + ex);
            }

        }

        public async Task Delete(ItemDto item)
        {
            var ItemEnti = new ItemEntities() { Id = item.Id };
            await _temRepository.Delete(ItemEnti);

        }


    }

}
