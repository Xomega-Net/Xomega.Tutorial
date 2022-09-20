//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class ProductCostHistoryConfig : IEntityTypeConfiguration<ProductCostHistory>
    {
        public void Configure(EntityTypeBuilder<ProductCostHistory> c)
        {
            c.ToTable("ProductCostHistory", "Production")
             .HasKey(e => new { e.ProductId, e.StartDate });

            // configure relationships

            c.HasOne(e => e.ProductObject)
             .WithOne()
             .HasForeignKey<ProductCostHistory>(e => e.ProductId);

            // configure properties
          
            c.Property(e => e.ProductId)
             .HasColumnName("ProductID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.StartDate)
             .HasColumnName("StartDate")
             .HasColumnType("datetime")
             .IsRequired();

            c.Property(e => e.EndDate)
             .HasColumnName("EndDate")
             .HasColumnType("datetime");

            c.Property(e => e.StandardCost)
             .HasColumnName("StandardCost")
             .HasColumnType("money")
             .IsRequired();

            c.Property(e => e.ModifiedDate)
             .HasColumnName("ModifiedDate")
             .HasColumnType("datetime")
             .IsRequired();

        }
    }
}