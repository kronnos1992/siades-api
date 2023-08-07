using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class DonorConfigurations : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.RefNumber)
                .IsRequired()
                .HasMaxLength(50)
                .Metadata.IsUniqueIndex();
            
            builder
                .Property(p => p.DonorType)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(x => x.GetPerson)
                .WithMany(x => x.DonorsList);


 
        }
    }
}