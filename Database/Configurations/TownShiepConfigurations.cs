using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class TownShiepConfigurations: IEntityTypeConfiguration<TownShiep>
    {
        public void Configure(EntityTypeBuilder<TownShiep> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.TownName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(p => p.ProvinceId)
                .Metadata.IsForeignKey();

            builder
                .HasMany(x => x.AddressesList)
                .WithOne(x => x.GetTownShiep);

            builder
                .HasOne(x => x.GetProvince)
                .WithMany(x => x.TownShiepsList);
        }
    }
}