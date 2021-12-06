using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class OwnersListConfiguration : IEntityTypeConfiguration<OwnersList>
{
    public void Configure(EntityTypeBuilder<OwnersList> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        //builder
          //  .OwnsOne(b => b.Colour);
    }
}
