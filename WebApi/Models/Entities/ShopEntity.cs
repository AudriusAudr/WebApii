namespace WebApi.Models.Entities
{
    public class ShopEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<ItemEntities> Items { get; set; }

        
    }
}
