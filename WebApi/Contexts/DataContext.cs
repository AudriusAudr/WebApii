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








//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    var connectionString = "User ID=postgres;Password=Wool84811;Host=localhost;Port=5432;Database=antradienis;";
//    object value = optionsBuilder.UseNpgsql(connectionString);
//}
