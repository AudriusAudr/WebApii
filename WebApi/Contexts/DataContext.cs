using System.Collections.Generic;
using WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<ShopEntity> Shops { get; set; }
    public DbSet<ItemEntities> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemEntities>()
            .HasOne(item => item.Shop)
            .WithMany(shop => shop.Items)
            .HasForeignKey(item => item.ShopEntityId);
    }
}





