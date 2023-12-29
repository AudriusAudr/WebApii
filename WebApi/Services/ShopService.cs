using System.Reflection.Metadata.Ecma335;
using WebApi.Models.DataTransferObject;
using WebApi.Models.Entities;
using WebApi.Repositories;



namespace WebApi.Services
{
    public class ShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly ITemRepository _temRepository;
        public ShopService(IShopRepository shopRepository, ITemRepository temRepository)
        {
            _shopRepository = shopRepository;
            _temRepository = temRepository;
        }

        public async Task<List<ShopEntity>> AllShop()
        {
            List<ShopEntity> Shop1 = new();
            var Shop = await _shopRepository.Shop();
            var shopEntity = Shop.Select(t => new ShopEntity
            {
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
            }).ToList();
            return shopEntity;

        }

        public async Task Create(ShopDto shop)
        {
            var entity = new ShopEntity
            {
                Name = shop.Name,
                Address = shop.Address
            };
            await _shopRepository.Create(entity);
        }

        public async Task<ShopDto> Get(int id)
        {
            var entity = await _shopRepository.GetShop(id);
            return new ShopDto { Name = entity.Name, Address = entity.Address };
        }

        public async Task Delete(int id)
        {
            var shopEntity = new ShopEntity() { Id = id };
            await _shopRepository.Delete(shopEntity);
        }

        public async Task PutItemToShop(int shopId, int itemId)
        {
            var shop = await _shopRepository.GetShop(shopId);
            var item = await _temRepository.GetItem(itemId);

            if (shop != null && item != null)
            {
                await _shopRepository.AddItemToShop(shop, item);
            }

        }


    }
}
