
namespace eShop.Data.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public string ProductName { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public Category Category { get; set; }

        public int CategoryId { set; get; }

    }
}
