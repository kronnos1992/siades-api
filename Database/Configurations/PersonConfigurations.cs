using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(p => p.IdentDocNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder
                .HasIndex(p => p.IdentDocNumber)
                .IsUnique();

            builder
                .Property(p => p.TypeIdentNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(x => x.GetAddress)
                .WithMany(x => x.People);

            builder
                .HasOne(x => x.GetContact)

                .WithOne(x => x.GetPerson)
                .HasForeignKey("Person", "ContactId");

            builder
                .HasOne(x => x.GetBlood)
                .WithMany(x => x.People);

            builder
                .HasMany(x => x.DoctorsList)
                .WithOne(x => x.GetPerson);

            builder
                .HasMany(x => x.DonorsList)
                .WithOne(x => x.GetPerson);
        }
    }
}