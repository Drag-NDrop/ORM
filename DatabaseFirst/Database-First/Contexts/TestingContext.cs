using System;
using System.Collections.Generic;
using Database_First.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_First.Contexts;

public partial class TestingContext : DbContext
{
    public TestingContext()
    {
    }

    public TestingContext(DbContextOptions<TestingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProductMapping> OrderProductMappings { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<VipCustomer> VipCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=::1;Initial Catalog=Testing;Integrated Security=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customers");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.HasIndex(e => e.CustomerId, "IX_orders_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<OrderProductMapping>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.OrderId, "IX_OrderProductMappings_OrderId");

            entity.HasIndex(e => e.ProductId, "IX_OrderProductMappings_ProductId");

            entity.HasOne(d => d.Order).WithMany().HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Product).WithMany().HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.HasIndex(e => e.OrderId, "IX_products_OrderId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.Products).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<VipCustomer>(entity =>
        {
            entity.ToTable("vipCustomers");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation)
                  .WithOne(p => p.VipCustomer)
                  .HasForeignKey<VipCustomer>(d => d.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
