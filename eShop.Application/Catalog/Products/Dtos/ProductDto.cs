using eShop.Data.Entities;

namespace eShop.Application.Catalog.Products.Dtos
{
    public class ProductDto
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }

        public int CategoryId { set; get; }
    }
}
