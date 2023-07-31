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
                . Property(p => p.SpecialityId)
                .Metadata.IsForeignKey();

            builder
                . Property(p => p.PersonId)
                .Metadata.IsForeignKey();

            builder
                .HasOne(x => x.GetSpeciality)
                .WithMany(x => x.Doctors);
            
            builder
                .HasOne(x => x.GetPerson)
                .WithMany(x => x.DoctorsList);
 
        }
    }
}