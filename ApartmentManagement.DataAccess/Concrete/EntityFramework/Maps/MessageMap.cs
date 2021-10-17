using ApartmentManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Maps
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(e => e.CreatedAt);

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Content)
                .IsRequired();

            builder.HasOne(d => d.ChatGroup)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.ChatGroupId);
        }
    }
}