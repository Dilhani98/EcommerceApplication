using Ecommerce.Api.Customers.Db;
using Ecommerce.Api.Customers.Interface;
using Ecommerce.Api.Customers.Profile;
using Ecommerce.Api.Customers.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomerDbContext>(opt =>
    opt.UseInMemoryDatabase("Customer"));

builder.Services.AddScoped<ICustomerService, CustomerProvider>();
builder.Services.AddAutoMapper(typeof(Customerprofile).Assembly);

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
