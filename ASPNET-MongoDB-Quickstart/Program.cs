using ASPNET_MongoDB_Quickstart.Services;
using ASPNET_MongoDB_Quickstart.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BankStoreDatabase>(
                builder.Configuration.GetSection("AccountsStoreDatabaseSettings"));

builder.Services.AddSingleton<IBankStoreDatabase>(sp =>
    sp.GetRequiredService<IOptions<BankStoreDatabase>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("AccountsStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IBankService, BankService>();

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
