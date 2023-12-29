using WebApi.Models.Entities;

public interface IShopRepository
{
    Task AddItemToShop(ShopEntity shop, ItemEntities item);
    Task Create(ShopEntity entity);
    Task Delete(ShopEntity entity);
    Task<ShopEntity> GetShop(int id);
    Task<List<ShopEntity>> Shop();
}