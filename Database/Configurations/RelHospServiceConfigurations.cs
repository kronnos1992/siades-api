using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class RelHospServiceConfigurations: IEntityTypeConfiguration<RelHospService>
    {
        public void Configure(EntityTypeBuilder<RelHospService> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.HospitalId)
                .Metadata.IsForeignKey();

            builder
                .Property(p => p.HospitalServiceId)
                .Metadata.IsForeignKey();

            builder 
                .HasOne(x => x.GetHospital)
                .WithMany(x => x.Services);

            builder 
                .HasOne(x => x.GetService)
                .WithMany(x => x.Hospitals);
        }
    }
}