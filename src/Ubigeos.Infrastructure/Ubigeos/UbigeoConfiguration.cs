using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubigeos.Domain.Ubigeos;

namespace Ubigeos.Infrastructure.Ubigeos;

public class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
{
    public void Configure(EntityTypeBuilder<Ubigeo> builder)
    {
        builder.ToTable("Ubigeo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
               .IsRequired()
               .HasMaxLength(6);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(x => x.Level)
               .IsRequired();

        builder.HasOne(x => x.Parent)
               .WithMany(x => x.Children)
               .HasForeignKey(x => x.ParentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ParentId);
        builder.HasIndex(x => new { x.Level, x.Code }).IsUnique();
    }
}