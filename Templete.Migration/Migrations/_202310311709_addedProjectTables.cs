using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Migration.Migrations
{
    [FluentMigrator.Migration(202310311709)]
    public class _202310311709_addedProjectTables : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Groups")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();
            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("Inventory").AsInt32().NotNullable()
                .WithColumn("MinimumInventory").AsInt32().NotNullable()
                .WithColumn("Condition").AsInt32().NotNullable()
                .WithColumn("GroupId").AsInt32().NotNullable()
                .ForeignKey("FK_Products_Groups","Groups" ,"Id");
            Create.Table("ProductArrivals")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("DateTime").AsDateTime().NotNullable()
                .WithColumn("Number").AsInt32().NotNullable()
                .WithColumn("InvoiceNumber").AsString().NotNullable()
                .WithColumn("CompanyName").AsString(50).NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("FK_ProductArrivals_Products", "Products", "Id");
            Create.Table("SalesInvoices")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CustomerName").AsString().NotNullable()
                .WithColumn("Number").AsInt32().NotNullable()
                .WithColumn("Price").AsInt32().NotNullable()
                .WithColumn("DateTime").AsDateTime().NotNullable()
                .WithColumn("InvoiceNumber").AsString().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("FK_SalesInvoices_Products", "Products", "Id");
            Create.Table("AccountingDocuments")
                .WithColumn("documentNumber").AsInt32().PrimaryKey().Identity()                
                .WithColumn("InvoiceNumber").AsString().NotNullable()
                .WithColumn("TotalAmount").AsInt32().NotNullable()
                .WithColumn("SalesInvoiceId").AsInt32().NotNullable()
                .ForeignKey("FK_AccountingDocuments_SalesInvoices", "SalesInvoices", "Id");
        }
        
        public override void Down()
        {
            Delete.Table("AccountingDocuments");
            Delete.Table("SalesInvoices");
            Delete.Table("ProductArrivals");
            Delete.Table("Products");
            Delete.Table("Groups");
        }

    }
}
