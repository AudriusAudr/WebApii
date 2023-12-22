//using WebApi.Models.Entities;
//using WebApi.Repositories;

//namespace WebApi.Services
//{
//    public class ItemService
//    {
//        private readonly ItemRepository _itemRepository;

//        public ItemService(ItemRepository itemRepository)
//        {
//            _itemRepository = itemRepository;
//        }

//        public bool Add(ItemEntities itemEntities)
//        {
//            return _itemRepository.Add(itemEntities);
//        }

//        public IEnumerable<ItemEntities> GetAll()
//        {
//            return _itemRepository.GetAll().ToList();
//        }

//        public int Edit(ItemEntities itemEntities)
//        {
//            return _itemRepository.Edit(itemEntities);
//        }

//        public int Delete(ItemEntities itemEntities)
//        {
//            return _itemRepository.Delete(itemEntities);
//        }

//        public ItemEntities GetById(int id)
//        {
//            return _itemRepository.GetById(id);
//        }

//        public Decimal? BuyItem(int id, int quantity)
//        {
//            var a = GetById(id);
//            if (a != null) 
//            { 
//               if (quantity >= 10)
//                {
//                    a.Price = a.Price * 0.9M;

//                }else if (quantity>=20) {

//                    a.Price = a.Price * 0.8M;
                    

//                }
//                return  a.Price;
            
//            }
//            return null;
            
//        }
//    }
//}
