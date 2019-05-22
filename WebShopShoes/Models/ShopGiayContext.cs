using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebShopShoes.Models
{
    public partial class ShopGiayContext : DbContext
    {
        public ShopGiayContext()
        {
        }

        public ShopGiayContext(DbContextOptions<ShopGiayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryNews> CategoryNews { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        // Unable to generate entity type for table 'dbo.OrderDetail'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DILLT61\\SQLEXPRESS;Database=ShopGiay;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<CategoryNews>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.NameColor).HasMaxLength(50);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Comments_Customers");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.NameImages)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.IdColor)
                    .HasConstraintName("FK_Model_Color");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("FK_Model_Images");

                entity.HasOne(d => d.IdSizeNavigation)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.IdSize)
                    .HasConstraintName("FK_Model_Size");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.CreateBy).HasMaxLength(150);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Descriptioin).HasMaxLength(255);

                entity.Property(e => e.Images)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_News_CategoryNews");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameProduct)
                .HasMaxLength(250)
                .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sale)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.IdModelNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Model");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameRole).HasMaxLength(50);

                entity.HasOne(d => d.IdCustomersNavigation)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.IdCustomers)
                    .HasConstraintName("FK_Role_Customers");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.NameSize)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
