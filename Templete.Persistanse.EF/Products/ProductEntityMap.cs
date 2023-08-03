using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.Persistanse.EF.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Title).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Condition).IsRequired();
            builder.Property(_ => _.MinimumInventory).IsRequired();
            builder.Property(_ => _.GroupId).IsRequired();
            builder.HasOne(_ => _.Group)
                .WithMany(_ => _.Products)
                .HasForeignKey(_ => _.GroupId);
        }
    }
}
