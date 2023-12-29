using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.DataTransferObject;
using WebApi.Models.Entities;
using WebApi.Repositories;

public class ShopRepository : IShopRepository
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

    public async Task<ShopEntity> GetShop(int id)
    {
        return _dataContext.Shops.FirstOrDefault(s => s.Id == id);
    }

    public async Task Delete(ShopEntity entity)
    {
        _dataContext.Shops.Remove(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task AddItemToShop(ShopEntity shop, ItemEntities item)
    {
        if (shop.Items == null)
        {
            shop.Items = new List<ItemEntities>();
        }
        else if (shop.Items.Any(i => i.Id == item.Id))
        {
            throw new InvalidOperationException("Item is already associated with the shop");
        }
        shop.Items.Add(item);

        await _dataContext.SaveChangesAsync();
    }
}