using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.Persistanse.EF.SalesInvoices
{
    public class SalesInvoiceEntityMap : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> builder)
        {
            builder.ToTable("SalesInvoices");
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.CustomerName).IsRequired();
            builder.Property(_ => _.InvoiceNumber).IsRequired();
            builder.Property(_ => _.DateTime).IsRequired();
            builder.Property(_ => _.Price).IsRequired();
            builder.Property(_ => _.Number).IsRequired();
            builder.HasOne(_ => _.Product)
                .WithMany(_ => _.SalesInvoices)
                .HasForeignKey(_ => _.ProductId);
        }
    }
}