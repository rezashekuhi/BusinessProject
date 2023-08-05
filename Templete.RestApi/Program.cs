using Templete.Persistanse.EF;
using Microsoft.EntityFrameworkCore;
using Templete.Services.Contracts;
using Templete.Services.Products.Contracts;
using Templete.Persistanse.EF.Products;
using Templete.Persistanse.EF.Groups;
using Templete.Services.Groups.Contracts;
using Templete.Services.Groups;
using Templete.Services.Products;
using Templete.Services.ProductArrivals.Contracts;
using Templete.Services.ProductArrivals;
using Templete.Persistanse.EF.ProductArrivals;
using Templete.Services.SalesInvoices.Contracts;
using Templete.Services.SalesInvoices;
using Templete.Persistanse.EF.SalesInvoices;
using Templete.Persistanse.EF.AccountingDocuments;
using Templete.Services.AccountingDocuments.Contract;
using Templete.Services.AccountingDocuments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<GroupService, GroupAppService>();
builder.Services.AddScoped<GroupRepository, EFGroupRepository>();
builder.Services.AddScoped<ProductService, ProductAppService>();
builder.Services.AddScoped<ProductRepository, EFProductRepository>();
builder.Services.AddScoped<ProductArrivalService, ProductArrivalAppService>();
builder.Services.AddScoped<ProductArrivalRepository, EFProductArrivalRepository>();
builder.Services.AddScoped<SalesInvoiceService, SalesInvoiceAppService>();
builder.Services.AddScoped<SalesInvoiceRepository, EFSalesInvoiceRepository>();
builder.Services.AddScoped<AccountingDocumentRepository, EFAccountingDocumentRepository>();
builder.Services.AddScoped<AccountingDocumentService, AccountingDocumentAppService>();

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