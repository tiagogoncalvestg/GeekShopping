using Microsoft.EntityFrameworkCore;
using Store.ProductApi.Contracts.RabbitMQSender;
using Store.ProductApi.Infrastructure.Contracts;
using Store.ProductApi.Infrastructure.Repositories;
using Store.ProductApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionStrings:ProductDB"];

builder.Services.AddDbContext<Store.ProductApi.Infrastructure.Context.AppContext>(opt => opt.UseSqlite(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
