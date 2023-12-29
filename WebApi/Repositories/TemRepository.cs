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
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<ItemEntities>> GetAll()
        {
        }

        public async Task<ItemEntities> GetItem(int id)
        {
        }

        public async Task Update(ItemEntities entity)
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(ItemEntities entiny)
        {
            await _dataContext?.SaveChangesAsync();
        }

    }
}
 