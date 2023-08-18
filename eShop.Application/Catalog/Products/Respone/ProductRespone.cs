using eShop.Data.Entities;

namespace eShop.Application.Catalog.Products.Respone
{
    public class ProductRespone
    {
        public int Id { set; get; }
        public string ProductName { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public int CategoryId { set; get; }

        public string CategoryName { set; get; }
    }
}
