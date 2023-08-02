using Templete.Persistanse.EF;
using Microsoft.EntityFrameworkCore;
using Templete.Services.Contracts;
using ShopApp.Services.Groups.Contract;
using ShopApp.Services.Groups;
using ShopApp.Persistanse.EF.Groups;
using Templete.Services.Products.Contracts;
using Templete.Persistanse.EF.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GroupService, GroupAppService>();
builder.Services.AddScoped<GroupRepository, EFGroupRepository>();
builder.Services.AddScoped<ProductRepository,EFProductRepository>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddDbContext<EFDataContext>(_ =>
    _.UseSqlServer("Server=.;Database=ShopDb;Trusted_Connection=True;"));
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();


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