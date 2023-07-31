using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class HospitalConfigurations : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.HospitalName)
                .IsRequired()
                .HasMaxLength(50)
                .Metadata.IsUniqueIndex();
            
            builder
                .Property(x => x.AddressId)
                .Metadata.IsForeignKey();
            
            builder
                .HasOne(x => x.GetAddress)
                .WithOne(x => x.GetHospital);
            
            builder
                .HasMany(x => x.ListRequest)
                .WithOne(x => x.GetHospital); 
        }
    }
}