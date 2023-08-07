using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder.Property(p => p.EmailAdrress)
                .IsRequired()
                .HasMaxLength(300);
            
            builder.Property(p => p.PhoneNumeber)
                .IsRequired()
                .HasMaxLength(16);

            builder
                .HasOne(p => p.GetPerson)
                .WithOne(p => p.GetContact);  
        }
    }
}