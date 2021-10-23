using System.Collections.Generic;
using ApartmentManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Maps
{
    public class ApartmentMap : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.Property(e => e.Block)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Door)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Floor)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(d => d.Occupant)
                .WithMany(p => p.Apartments)
                .HasForeignKey(d => d.OccupantId);
        }
    }
}