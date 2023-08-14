using eShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.EF
{
    public class eShopDbContext : DbContext
    {
        public eShopDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>(c =>
            {
                c.HasKey(p => p.Id);
                c.HasOne(e => e.Product).WithMany().HasForeignKey(e=> e.ProductId);
            });
            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p => p.Id);
                p.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Cart>(c =>
            {
                c.HasKey(c => c.Id);
                c.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ProductId);
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(e => e.Id);
            });

            modelBuilder.Entity<OrderDetail>(o =>
            {
                o.HasKey(e => new { e.OrderId, e.ProductId });
                o.HasOne(e => e.Order).WithMany(e => e.OrderDetails).HasForeignKey(e => e.OrderId);
                o.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ProductId);
            });
        }

    }
}
