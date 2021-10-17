using ApartmentManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Maps
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(e => e.AmountPayable);

            builder.Property(e => e.DueDate);

            builder.HasOne(d => d.Apartment)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ApartmentId);

            builder.HasOne(d => d.InvoiceType)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.InvoiceTypeId);
        }
    }
}