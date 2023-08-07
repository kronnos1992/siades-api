using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.DocNumber)
                .IsRequired()
                .HasMaxLength(50)
                .Metadata.IsUniqueIndex();

            builder
                .Property(p => p.BloodGroupName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasIndex(p => p.BloodGroupName)
                .IsUnique();

            builder
                .HasMany(x => x.Specialities)
                .WithOne(x => x.GetDoctor);

            builder
                .HasOne(x => x.GetPerson)
                .WithMany(x => x.DoctorsList);

        }
    }
}