using WebApi.Models.Entities;
using WebApi.Models.DataTransferObject;
using WebApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.Connections;



namespace WebApi.Repositories
{
    public class TemRepository : ITemRepository
    {
        private readonly DataContext _dataContext;
        public TemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task Create(ItemEntities entities)
        {
            _dataContext.Items.Add(entities);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<ItemEntities>> GetAll()
        {
            return await _dataContext.Items.ToListAsync();
        }

        public async Task<ItemEntities> GetItem(int id)
        {
            return await _dataContext.Items.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Update(ItemEntities entity)
        {
            _dataContext.Items.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(ItemEntities entiny)
        {
            _dataContext?.Items.Remove(entiny);
            await _dataContext?.SaveChangesAsync();
        }

    }
}
 