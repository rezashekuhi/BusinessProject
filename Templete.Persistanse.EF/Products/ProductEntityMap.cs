using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(_=>_.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Title).HasMaxLength(50).IsRequired();
            builder.Property(_=>_.Condition).IsRequired();
            builder.Property(_ => _.MinimumInventory).IsRequired();
            builder.Property(_=>_.GroupId).IsRequired();
            builder.HasOne(_ => _.Group)
                .WithMany(_ => _.Products)
                .HasForeignKey(_ => _.GroupId);
        }
    }
}
