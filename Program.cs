using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Helpers.Mappers;
using Ecommerce_BE.Repositories.Ingerdients;
using Ecommerce_BE.Services.ManagerServices;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string _connectString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<EcommerceContext>(
    options=> options.UseMySql(_connectString,ServerVersion.AutoDetect(_connectString),option=>
    {
        option.EnableStringComparisonTranslations();
    }));


builder.Services.AddAutoMapper(typeof(BusinessMapper));
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IManagerService, ManagerService>();
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
