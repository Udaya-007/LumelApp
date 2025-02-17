using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LumelApp.Models;

public partial class LumelDbContext : DbContext
{
    public LumelDbContext()
    {
    }

    public LumelDbContext(DbContextOptions<LumelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DiscountType> DiscountTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\LocalDB_Udaya;Database=LUMEL_DB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07760ACD7C");

            entity.HasIndex(e => e.Id, "UQ__Customer__3214EC06357E6C92").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053492E916E4").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DiscountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC074A3F0522");

            entity.HasIndex(e => e.Id, "UQ__Discount__3214EC06502992D5").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC070D7D2B26");

            entity.HasIndex(e => e.Id, "UQ__Orders__3214EC065A87CA25").IsUnique();

            entity.Property(e => e.DateOfSale).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Orders_fk1");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Orders_fk4");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07C8939486");

            entity.HasIndex(e => e.Id, "UQ__OrderIte__3214EC06865EA5CA").IsUnique();

            entity.Property(e => e.ActualDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedDeliveryDate).HasColumnType("datetime");

            entity.HasOne(d => d.DiscountType).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.DiscountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderItems_fk5");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderItems_fk1");

            entity.HasOne(d => d.OrderStaus).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderStausId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderItems_fk10");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderItems_fk2");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC07472C681C");

            entity.HasIndex(e => e.Id, "UQ__OrderSta__3214EC062FF25CD8").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentM__3214EC07F30394DA");

            entity.HasIndex(e => e.Id, "UQ__PaymentM__3214EC0660D3565C").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07B1389856");

            entity.HasIndex(e => e.Id, "UQ__Products__3214EC0660C8DA8A").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Products_fk2");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3214EC073CB2D2FC");

            entity.HasIndex(e => e.Id, "UQ__ProductC__3214EC069673C961").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
