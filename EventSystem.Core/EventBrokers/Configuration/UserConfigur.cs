using EventSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EventSystem.Core.EventBrokers.Configuration;
public class UserConfigur : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(30);
    }
}
