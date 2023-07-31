using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class SpecialityConfigurations : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.SpecialityName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(x => x.Doctors)
                .WithOne(x => x.GetSpeciality);
        }
    }
}