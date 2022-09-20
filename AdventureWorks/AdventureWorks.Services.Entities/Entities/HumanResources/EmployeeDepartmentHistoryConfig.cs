//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Services.Entities
{
    public class EmployeeDepartmentHistoryConfig : IEntityTypeConfiguration<EmployeeDepartmentHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartmentHistory> c)
        {
            c.ToTable("EmployeeDepartmentHistory", "HumanResources")
             .HasKey(e => new { e.BusinessEntityId, e.StartDate, e.DepartmentId, e.ShiftId });

            // configure relationships

            c.HasOne(e => e.BusinessEntityObject)
             .WithOne()
             .HasForeignKey<EmployeeDepartmentHistory>(e => e.BusinessEntityId);

            c.HasOne(e => e.DepartmentObject)
             .WithOne()
             .HasForeignKey<EmployeeDepartmentHistory>(e => e.DepartmentId);

            c.HasOne(e => e.ShiftObject)
             .WithOne()
             .HasForeignKey<EmployeeDepartmentHistory>(e => e.ShiftId);

            // configure properties
          
            c.Property(e => e.BusinessEntityId)
             .HasColumnName("BusinessEntityID")
             .HasColumnType("int")
             .IsRequired();

            c.Property(e => e.StartDate)
             .HasColumnName("StartDate")
             .HasColumnType("date")
             .IsRequired();

            c.Property(e => e.DepartmentId)
             .HasColumnName("DepartmentID")
             .HasColumnType("smallint")
             .IsRequired();

            c.Property(e => e.ShiftId)
             .HasColumnName("ShiftID")
             .HasColumnType("tinyint")
             .IsRequired();

            c.Property(e => e.EndDate)
             .HasColumnName("EndDate")
             .HasColumnType("date");

            c.Property(e => e.ModifiedDate)
             .HasColumnName("ModifiedDate")
             .HasColumnType("datetime")
             .IsRequired();

        }
    }
}