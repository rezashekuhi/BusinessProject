using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.ProductArrivals
{
    public class ProductArrivalEntityMap : IEntityTypeConfiguration<ProductArrival>
    {
        public void Configure(EntityTypeBuilder<ProductArrival> builder)
        {
            builder.ToTable("ProductArrivals");
            builder.HasKey(_=>_.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.CompanyName).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.InvoiceNumber).IsRequired();
            builder.Property(_ => _.DateTime).IsRequired();
            builder.Property(_ => _.ProductId).IsRequired();
            builder.HasOne(_ => _.Product)
                .WithMany(_ => _.ProductArrivals)
                .HasForeignKey(_ => _.ProductId);
        }
    }
}
