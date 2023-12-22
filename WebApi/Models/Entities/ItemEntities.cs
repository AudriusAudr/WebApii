namespace WebApi.Models.Entities
{
    public class ItemEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int ShopEntityId { get; set; }
        public ShopEntity Shop { get; set; }
    }   
}
