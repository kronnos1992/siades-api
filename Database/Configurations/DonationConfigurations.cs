using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class DonationConfigurations : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {

            builder
                .HasOne(p => p.GetDonor)
                .WithMany(p => p.Donations);

            builder
                .Property(p => p.BloodGroup)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}