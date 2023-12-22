using System.Collections.Generic;
using WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Contexts;

public class DataContext : DbContext
{
    public DbSet<ItemEntities> Item { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    var connectionString = "User ID=postgres;Password=Wool84811;Host=localhost;Port=5432;Database=antradienis;";
    //    object value = optionsBuilder.UseNpgsql(connectionString);
    //}
}
