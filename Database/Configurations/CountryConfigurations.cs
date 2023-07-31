using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.CountryName)
                .HasMaxLength(60)
                .IsRequired();

            builder
                .Property(p => p.PhoneCode)
                .HasMaxLength(5)
                .IsRequired(); 

            builder
                .HasMany(p => p.ProvinceList)
                .WithOne(p => p.GetCountry);          
           
        }
    }
}