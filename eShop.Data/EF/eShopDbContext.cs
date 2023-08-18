using eShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.EF
{
    public class EShopDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public EShopDbContext(DbContextOptions options) : base(options)
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
                c.HasOne(e => e.AppUser).WithMany().HasForeignKey(e=> e.UserId);
                
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
                c.HasOne(e => e.AppUser).WithMany().HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(e => e.Id);
                o.HasOne(e => e.AppUser).WithMany().HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<OrderDetail>(o =>
            {
                o.HasKey(e => new { e.OrderId, e.ProductId });
                o.HasOne(e => e.Order).WithMany(e => e.OrderDetails).HasForeignKey(e => e.OrderId);
                o.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ProductId);
            });

            modelBuilder.Entity<AppUser>(e =>
            {
                e.ToTable("AppUsers");
            });          
            modelBuilder.Entity<AppRole>(e =>
            {
                e.ToTable("AppRoles");
            });          
            modelBuilder.Entity<IdentityUserClaim<Guid>>(e =>
            {
                e.ToTable("AppUserClaim");
            });
                        
            modelBuilder.Entity<IdentityUserRole<Guid>>(e =>
            {
                e.ToTable("AppUserRole");
                e.HasKey(x => new { x.UserId , x.RoleId});
            });            
            modelBuilder.Entity<IdentityUserLogin<Guid>>(e =>
            {
                e.ToTable("AppUserLogin");
                e.HasKey(x => x.UserId);
            });
                        
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(e =>
            {
                e.ToTable("AppRoleClaim");
            });            
            modelBuilder.Entity<IdentityUserToken<Guid>>(e =>
            {
                e.ToTable("AppUserToken");
                e.HasKey(x => x.UserId);
            });

        }

    }
}
