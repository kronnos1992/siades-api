using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class BloodConfigurations : IEntityTypeConfiguration<Blood>
    {
        public void Configure(EntityTypeBuilder<Blood> builder)
        {
            builder
                .Property(p => p.BloodGroupName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasIndex(p => p.BloodGroupName)
                .IsUnique();

            builder
                .HasMany(p => p.ListRequest)
                .WithOne(p => p.GetBlood);

            builder
                .HasMany(p => p.People)
                .WithOne(p => p.GetBlood);


        }
    }
}