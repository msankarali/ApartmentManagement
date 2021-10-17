using ApartmentManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Maps
{
    public class ChatGroupMap : IEntityTypeConfiguration<ChatGroup>
    {
        public void Configure(EntityTypeBuilder<ChatGroup> builder)
        {
            builder.HasIndex(e => e.ManagerId)
                .IsUnique();

            builder.HasIndex(e => e.OccupantId)
                .IsUnique();

            builder.HasOne(d => d.Manager)
                .WithOne(p => p.ChatGroup)
                .HasForeignKey<ChatGroup>(d => d.ManagerId);

            builder.HasOne(d => d.Occupant)
                .WithOne(p => p.ChatGroup)
                .HasForeignKey<ChatGroup>(d => d.OccupantId);
        }
    }
}