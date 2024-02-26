using Ecommerce.APi.Search.Interface;
using Ecommerce.APi.Search.Service;
using Polly;

var builder = WebApplication.CreateBuilder(args);
// Build the configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddSingleton(configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchInterface, SearchService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddHttpClient("OrderService", config => {
    config.BaseAddress = new Uri(configuration["Service:Orders"]);
}).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500))); ;
builder.Services.AddHttpClient("ProductService", config => {
    config.BaseAddress = new Uri(configuration["Service:Products"]);
}).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(5,_ => TimeSpan.FromMilliseconds(500) ));

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
