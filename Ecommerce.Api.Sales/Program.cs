using Ecommerce.Api.Sales.Db;
using Ecommerce.Api.Sales.Interface;
using Ecommerce.Api.Sales.Orderprofile;
using Ecommerce.Api.Sales.Provider;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(opt =>
    opt.UseInMemoryDatabase("Order"));

builder.Services.AddScoped<IOrderProvide, Orderprovider>();
builder.Services.AddAutoMapper(typeof(Orderprofile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
