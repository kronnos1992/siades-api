using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class HospitalServiceConfigurations : IEntityTypeConfiguration<HospitalService>
    {
        public void Configure(EntityTypeBuilder<HospitalService> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.ServiceName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(p => p.Hospitals)
                .WithOne(p => p.GetService);
        }
    }
}