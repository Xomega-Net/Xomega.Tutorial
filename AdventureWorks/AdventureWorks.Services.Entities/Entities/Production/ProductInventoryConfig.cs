//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class ProductInventoryConfig : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> c)
        {
            c.ToTable("ProductInventory", "Production")
             .HasKey(e => new { e.ProductId, e.LocationId });

            // configure relationships

            c.HasOne(e => e.ProductObject)
             .WithOne()
             .HasForeignKey<ProductInventory>(e => e.ProductId);

            c.HasOne(e => e.LocationObject)
             .WithOne()
             .HasForeignKey<ProductInventory>(e => e.LocationId);

            // configure properties
          
            c.Property(e => e.ProductId)
             .HasColumnName("ProductID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.LocationId)
             .HasColumnName("LocationID")
             .HasColumnType("smallint")
             .IsRequired();

            c.Property(e => e.Shelf)
             .HasColumnName("Shelf")
             .HasColumnType("nvarchar")
             .HasMaxLength(10)
             .IsUnicode()
             .IsRequired();

            c.Property(e => e.Bin)
             .HasColumnName("Bin")
             .HasColumnType("tinyint")
             .IsRequired();

            c.Property(e => e.Quantity)
             .HasColumnName("Quantity")
             .HasColumnType("smallint")
             .IsRequired();

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