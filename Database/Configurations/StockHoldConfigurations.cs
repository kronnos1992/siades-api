using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class StockHoldConfigurations: IEntityTypeConfiguration<StockHold>
    {
        public void Configure(EntityTypeBuilder<StockHold> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.BloodId)
                .Metadata.IsForeignKey();

            builder 
                .HasOne(p => p.GetBlood);
        }
    }
}