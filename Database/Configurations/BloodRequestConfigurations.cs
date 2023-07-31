using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class BloodRequestConfigurations : IEntityTypeConfiguration<BloodRequest>
    {
        public void Configure(EntityTypeBuilder<BloodRequest> builder)
        {
            builder
                .Property(p => p.DiseasedName)
                .IsRequired()
                .HasMaxLength(200);
            
            builder
                .Property(p => p.DiseasedAge)
                .IsRequired();
            
            builder
                .HasOne(p => p.GetHospital)
                .WithMany(p => p.ListRequest);
            
            builder
                .HasOne(p => p.GetBlood)
                .WithMany(p => p.ListRequest);
            
            builder
                .HasOne(p => p.GetDonor);

            builder
                .Property(p => p.DonorId)
                .Metadata.IsForeignKey();
            
            builder
                .Property(p => p.HospitalId)
                .Metadata.IsForeignKey();
            
                
        }
    }
}