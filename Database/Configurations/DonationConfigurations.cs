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
                .Property(p => p.DonorId)
                .Metadata.IsForeignKey();
            
            builder
                .Property(p => p.StockHoldId)
                .Metadata.IsForeignKey();
            
            builder
                .HasOne(p => p.GetDonor)
                .WithMany(p => p.Donations);
            
            builder
                .HasOne(p => p.GetStock);
 
        }
    }
}