using eShop.Application.Dtos;

namespace eShop.Application.Catalog.Products.Request
{
    public class ProductSearch : PagingRequestBase
    {
        public string productname { get; set; }
    }
}
