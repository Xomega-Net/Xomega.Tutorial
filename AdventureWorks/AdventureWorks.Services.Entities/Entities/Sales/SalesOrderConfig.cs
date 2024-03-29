//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class SalesOrderConfig : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> c)
        {
            c.ToTable("SalesOrderHeader", "Sales", tb => tb.UseSqlOutputClause(false))
             .HasKey(e => e.SalesOrderId);

            // configure relationships

            c.HasOne(e => e.CustomerObject)
             .WithMany()
             .HasForeignKey(e => e.CustomerId);

            c.HasOne(e => e.SalesPersonObject)
             .WithMany()
             .HasForeignKey(e => e.SalesPersonId);

            c.HasOne(e => e.TerritoryObject)
             .WithMany()
             .HasForeignKey(e => e.TerritoryId);

            c.HasOne(e => e.BillToAddressObject)
             .WithMany()
             .HasForeignKey(e => e.BillToAddressId);

            c.HasOne(e => e.ShipToAddressObject)
             .WithMany()
             .HasForeignKey(e => e.ShipToAddressId);

            c.HasOne(e => e.ShipMethodObject)
             .WithMany()
             .HasForeignKey(e => e.ShipMethodId);

            c.HasOne(e => e.CreditCardObject)
             .WithMany()
             .HasForeignKey(e => e.CreditCardId);

            c.HasOne(e => e.CurrencyRateObject)
             .WithMany()
             .HasForeignKey(e => e.CurrencyRateId);

            // configure properties
          
            c.Property(e => e.SalesOrderId)
             .HasColumnName("SalesOrderID")
             .HasColumnType("int")
             .IsRequired()
             .ValueGeneratedOnAdd();

            c.Property(e => e.RevisionNumber)
             .HasColumnName("RevisionNumber")
             .HasColumnType("tinyint")
             .IsRequired();

            c.Property(e => e.OrderDate)
             .HasColumnName("OrderDate")
             .HasColumnType("datetime")
             .IsRequired();

            c.Property(e => e.DueDate)
             .HasColumnName("DueDate")
             .HasColumnType("datetime")
             .IsRequired();

            c.Property(e => e.ShipDate)
             .HasColumnName("ShipDate")
             .HasColumnType("datetime");

            c.Property(e => e.Status)
             .HasColumnName("Status")
             .HasColumnType("tinyint")
             .IsRequired();

            c.Property(e => e.OnlineOrderFlag)
             .HasColumnName("OnlineOrderFlag")
             .HasColumnType("bit")
             .IsRequired();

            c.Property(e => e.SalesOrderNumber)
             .HasColumnName("SalesOrderNumber")
             .HasColumnType("nvarchar")
             .HasMaxLength(25)
             .IsUnicode()
             .IsRequired()
             .ValueGeneratedOnAddOrUpdate();

            c.Property(e => e.PurchaseOrderNumber)
             .HasColumnName("PurchaseOrderNumber")
             .HasColumnType("nvarchar")
             .HasMaxLength(25)
             .IsUnicode();

            c.Property(e => e.AccountNumber)
             .HasColumnName("AccountNumber")
             .HasColumnType("nvarchar")
             .HasMaxLength(15)
             .IsUnicode();

            c.Property(e => e.CustomerId)
             .HasColumnName("CustomerID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.SalesPersonId)
             .HasColumnName("SalesPersonID")
             .HasColumnType("int");

            c.Property(e => e.TerritoryId)
             .HasColumnName("TerritoryID")
             .HasColumnType("int");

            c.Property(e => e.BillToAddressId)
             .HasColumnName("BillToAddressID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.ShipToAddressId)
             .HasColumnName("ShipToAddressID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.ShipMethodId)
             .HasColumnName("ShipMethodID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.CreditCardId)
             .HasColumnName("CreditCardID")
             .HasColumnType("int");

            c.Property(e => e.CreditCardApprovalCode)
             .HasColumnName("CreditCardApprovalCode")
             .HasColumnType("varchar")
             .HasMaxLength(15);

            c.Property(e => e.CurrencyRateId)
             .HasColumnName("CurrencyRateID")
             .HasColumnType("int");

            c.Property(e => e.SubTotal)
             .HasColumnName("SubTotal")
             .HasColumnType("money")
             .IsRequired();

            c.Property(e => e.TaxAmt)
             .HasColumnName("TaxAmt")
             .HasColumnType("money")
             .IsRequired();

            c.Property(e => e.Freight)
             .HasColumnName("Freight")
             .HasColumnType("money")
             .IsRequired();

            c.Property(e => e.TotalDue)
             .HasColumnName("TotalDue")
             .HasColumnType("money")
             .IsRequired()
             .ValueGeneratedOnAddOrUpdate();

            c.Property(e => e.Comment)
             .HasColumnName("Comment")
             .HasColumnType("nvarchar")
             .HasMaxLength(128)
             .IsUnicode();

            c.Property(e => e.Rowguid)
             .HasColumnName("rowguid")
             .HasColumnType("uniqueidentifier")
             .IsRequired();

            c.Property(e => e.ModifiedDate)
             .HasColumnName("ModifiedDate")
             .HasColumnType("datetime")
             .IsRequired();

        }
    }
}