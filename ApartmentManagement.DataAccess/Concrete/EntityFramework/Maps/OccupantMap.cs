﻿using ApartmentManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Maps
{
    public class OccupantMap : IEntityTypeConfiguration<Occupant>
    {
        public void Configure(EntityTypeBuilder<Occupant> builder)
        {
            builder.Property(e => e.CarPlate).HasMaxLength(30);

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IdentityNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(e => e.Mail)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}