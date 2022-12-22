using EventSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EventSystem.Core.EventBrokers.Configuration;
public class RoomConfigur : IEntityTypeConfiguration<Rooms>
{
    public void Configure(EntityTypeBuilder<Rooms> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.RoomName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
