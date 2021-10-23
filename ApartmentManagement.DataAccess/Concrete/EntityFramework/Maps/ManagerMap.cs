using ApartmentManagement.Entities.Models;
using Core.Utilities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Maps
{
    public class ManagerMap : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(128);

            HashingHelper.CreatePasswordHash("test", out var passwordHash, out var passwordSalt);

            var testManager = new Manager
            {
                Id = 1,
                FullName = "Kenân",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            builder.HasData(testManager);
        }
    }
}