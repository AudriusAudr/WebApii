using WebApi.Models.DataTransferObject;
using WebApi.Models.Entities;
using WebApi.Repositories;



namespace WebApi.Services
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;
        public ShopService(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<List<ShopEntity>> AllShop()
        {
            List<ShopEntity> Shop1 = new();
            var Shop = await _shopRepository.Shop();
            var shopEntity = Shop.Select(t=>new ShopEntity
            {
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
            }).ToList();
            return shopEntity;

        }

        public async Task Create(ShopDto shop)
        {
            var entity = new ShopDto
            {
                Name = shop.Name,
                Address = shop.Address
            };
            await _shopRepository.Create(shop);
        }


    }
}
