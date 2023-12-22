using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.DataTransferObject;
using WebApi.Models.Entities;
using WebApi.Repositories;

public class ShopRepository
{
    private readonly DataContext _dataContext;
    public ShopRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }


    public async Task<List<ShopEntity>> Shop()
    {
        return await _dataContext.Shops.ToListAsync();
    }

    public async Task Create(ShopEntity entity)
    {
        _dataContext.Shops.Add(entity);
        await _dataContext.SaveChangesAsync();
    }
}