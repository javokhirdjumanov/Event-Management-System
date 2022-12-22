using EventSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EventSystem.Core.EventBrokers.Configuration;
public class EventConfigur : IEntityTypeConfiguration<Events>
{
    public void Configure(EntityTypeBuilder<Events> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder
            .Property(x => x.EventName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
