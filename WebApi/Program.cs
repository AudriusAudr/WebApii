using Npgsql;
using System.Data;
using WebApi.Contexts;
using WebApi.Repositories;
using WebApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Exceptions;
using WebApi.Middlewares;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");
//builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(dbConnectionString) );
//builder.Services.AddScoped<ItemRepository>();
//builder.Services.AddScoped<ItemService>();


//builder.Services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("MyDatabase"));
builder.Services.AddScoped<ITemRepository, TemRepository>();
builder.Services.AddScoped<TemService>();


string conncetion = builder.Configuration.GetConnectionString("PostgreConnection");
builder.Services.AddDbContext<DataContext>(o => o.UseNpgsql(conncetion));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
