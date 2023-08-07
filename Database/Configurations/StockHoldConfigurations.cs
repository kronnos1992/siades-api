using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models;

namespace siades.Database.Configurations
{
    public class StockHoldConfigurations : IEntityTypeConfiguration<StockHold>
    {
        public void Configure(EntityTypeBuilder<StockHold> builder)
        {
            builder
                .HasKey(p => p.StockHoldId);

            builder
                .HasIndex(p => p.StockHoldId)
                .IsUnique();
        }
    }
}