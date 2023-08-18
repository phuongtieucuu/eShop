using eShop.Application.Catalog.Products.DI;
using eShop.Application.Catalog.Products.Dtos;
using eShop.Application.Catalog.Products.Request;
using eShop.Application.Catalog.Products.Respone;
using eShop.Application.Dtos;
using eShop.Data.EF;
using eShop.Data.Entities;
using eShop.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eShop.Application.Catalog.Products
{
    public class ProductAdminVervice : IProductAdminVervice
    {
        private readonly EShopDbContext _context;
        public ProductAdminVervice(EShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateProduct(ProductDto request)
        {
            Product product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                DateCreated = DateTime.Now,
                ViewCount = 0,
                Category = new Category()
                {
                    Name = "Ao",
                    DateCreated = DateTime.Now,
                }
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new EShopException("Cannot Find Product!!");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageImpl<ProductRespone>> Search(ProductSearch request)
        {
            var query = (from p in _context.Products
                         join c in _context.Categories on p.CategoryId equals c.Id
                         select new
                         {
                             p,
                             CategoryName = c.Name,
                         });
            if(!string.IsNullOrEmpty(request.productname))
            {
                query = query.Where(x => x.p.ProductName.Contains(request.productname));
            }

            int totalElement = await query.CountAsync();
            int page = request.page.renderPage();
            int size = request.page.renderSize();
            var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();

            var result =   new PageImpl<ProductRespone>()
            {
                page = page,
                size = size,
                totalElement = totalElement,
                totalPage = int.Parse(Math.Ceiling((decimal)(totalElement / size)),
               
            };

        }

        public async Task<int> UpdateProduct(ProductDto request)
        {
            throw new NotImplementedException();
        }
    }
}
