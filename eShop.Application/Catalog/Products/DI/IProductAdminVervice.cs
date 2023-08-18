using eShop.Application.Catalog.Products.Dtos;
using eShop.Application.Catalog.Products.Request;
using eShop.Application.Catalog.Products.Respone;
using eShop.Application.Dtos;

namespace eShop.Application.Catalog.Products.DI
{
    public interface IProductAdminVervice
    {
        Task<int> CreateProduct(ProductDto request);
        Task<int> UpdateProduct(ProductDto request);
        Task<int> DeleteProduct(int id);

        Task<PageImpl<ProductRespone>> Search(ProductSearch request);
    }
}
