using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DataTransferObject;

namespace WebApi.Services
{
    public interface ITemService
    {
        Task Create(ItemDto itemDto);
        Task Delete(ItemDto item);
        Task<ItemDto> Get(int id);
        Task<List<ItemDto>> GetAll();
        Task Update(ItemDto item);
    }
}
