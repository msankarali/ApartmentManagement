using ApartmentManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Maps
{
    public class InvoiceTypeMap : IEntityTypeConfiguration<InvoiceType>
    {
        public void Configure(EntityTypeBuilder<InvoiceType> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new InvoiceType { Id = 1, Name = "Aidat" },
                new InvoiceType { Id = 2, Name = "Elektrik" },
                new InvoiceType { Id = 3, Name = "Su" },
                new InvoiceType { Id = 4, Name = "Doğalgaz" }
                );
        }
    }
}