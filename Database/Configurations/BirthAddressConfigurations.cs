using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class BirthAddressConfigurations: IEntityTypeConfiguration<BirthAddress>
    {
        public void Configure(EntityTypeBuilder<BirthAddress> builder)
        {
           builder
                .HasKey(p => p.Id);
            builder
                .HasMany(p => p.People);
            //.WithOne(p => p.GetBirthAddress);

            builder.Property(p => p.TownShiepId)
                .Metadata.IsForeignKey();

            builder
                .HasOne(p => p.GetTownShiep)
                .WithMany(p => p.BirthAddressesList);
            
            builder.Property(p => p.BirthHouseNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            
            builder.Property(p => p.BirthStreet)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(p => p.BirthNeighborHud)
                    .IsRequired()
                    .HasMaxLength(50);

            
        }
    }
}