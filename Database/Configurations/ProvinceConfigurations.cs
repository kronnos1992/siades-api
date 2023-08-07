using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class ProvinceConfigurations : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.ProvinceName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.GeoLocation)
                .HasMaxLength(50);

            builder
                .HasOne(x => x.GetCountry)
                .WithMany(x => x.ProvinceList);
            
            builder 
                .HasMany(x => x.TownShiepsList)
                .WithOne(x => x.GetProvince);
        
        }
    }
}