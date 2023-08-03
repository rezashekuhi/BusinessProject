using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templete.Entities;

namespace Templete.Persistanse.EF.AccountingDocuments
{
    public class AccountingDocumentEnityMap : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> builder)
        {
            builder.ToTable("AccountingDocuments");
            builder.HasKey(_ => _.documentNumber);
            builder.Property(_ => _.documentNumber).ValueGeneratedOnAdd();
            builder.Property(_ => _.SalesInvoiceId).IsRequired();
            builder.Property(_ => _.TotalAmount).IsRequired();
            builder.HasOne(_ => _.SalesInvoice)
                .WithMany(_ => _.AccountingDocuments)
                .HasForeignKey(_ => _.SalesInvoiceId);
        }
    }
}
