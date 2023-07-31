using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(p => p.Id);
            builder
                .HasMany(p => p.People)
                .WithOne(p => p.GetAddress);

            builder
                .HasOne(p => p.GetTownShiep)
                .WithMany(p => p.AddressesList);
            
            builder.Property(p => p.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            
            builder.Property(p => p.Street)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.NeighborHud)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.TownShiepId)
                   .Metadata.IsForeignKey();
                   
        }
    }
}