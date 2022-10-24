using EFCoreDay2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDay2.Data
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                             .ToTable("Category")
                             .HasKey(cat => cat.Id);
            modelBuilder.Entity<Category>()
                             .Property(cat => cat.Id)
                             .HasColumnName("CategoryId")
                             .HasColumnType("int")
                             .IsRequired()
                             .UseIdentityColumn(1);
            modelBuilder.Entity<Category>()
                             .Property(cat => cat.Name)
                             .HasColumnName("CategoryName")
                             .HasColumnType("nvarchar")
                             .HasMaxLength(100);
            modelBuilder.Entity<Product>()
                             .ToTable("Product")
                             .HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                             .HasOne<Category>(s => s.Category)
                             .WithMany(p => p.Products)
                             .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                             .Property(p => p.ProductId)
                             .HasColumnName("ProductId")
                             .HasColumnType("int")
                             .IsRequired()
                             .UseIdentityColumn(1);
            modelBuilder.Entity<Product>()
                             .Property(cat => cat.ProductName)
                             .HasColumnName("ProductName")
                             .HasColumnType("nvarchar")
                             .HasMaxLength(100)
                             .IsRequired();
            modelBuilder.Entity<Product>()
                             .Property(cat => cat.Manufacture)
                             .HasColumnName("Manufacture")
                             .HasColumnType("nvarchar")
                             .HasMaxLength(100)
                             .IsRequired();
            modelBuilder.Entity<Product>()
                             .Property(cat => cat.CategoryId)
                             .HasColumnName("Category")
                             .HasColumnType("int")
                             .IsRequired();
            modelBuilder.Entity<Category>()
                             .HasData(new Category
                             {
                                 Id = 1,
                                 Name = "Computer"
                             });
            modelBuilder.Entity<Product>()
                            .HasData(new Product
                            {
                                ProductId = 1,
                                ProductName = "Casio",
                                CategoryId = 1,
                                Manufacture = "test"
                            });

        }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
    }
}