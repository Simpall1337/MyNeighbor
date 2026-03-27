using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNeighbor.Domain.Housing;

namespace MyNeighbor.Infrastructure.Persistence.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.OwnsOne(b => b.Address, address =>
            {
                address.Property(a => a.City).HasColumnName("City").IsRequired();
                address.Property(a => a.Street).HasColumnName("Street").IsRequired();
                address.Property(a => a.HouseNumber).HasColumnName("HouseNumber").IsRequired();
            });

            builder.HasMany(b => b.Apartments)
                   .WithOne()
                   .HasForeignKey(a => a.BuildingId);

            builder.Navigation(b => b.Apartments)
                   .HasField("_apartments");
        }
    }
}
