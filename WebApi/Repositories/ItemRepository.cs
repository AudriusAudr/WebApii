using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public interface ITemRepository
    {
        Task Create(ItemEntities entities);
        Task Delete(ItemEntities entiny);
        Task<List<ItemEntities>> GetAll();
        Task<ItemEntities> GetItem(int id);
        Task Update(ItemEntities entity);
    }
}