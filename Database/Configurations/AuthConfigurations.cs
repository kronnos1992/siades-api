

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using siades.Models.Auth;

namespace siades.Database.Configurations
{
    public class AuthConfigurations : IEntityTypeConfiguration<AppRoleToUser>
    {
        public void Configure(EntityTypeBuilder<AppRoleToUser> builder)
        {
            builder
                .HasKey(p => new { p.UserId, p.RoleId });

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Roles)
                .HasForeignKey(p => p.UserId)
                .IsRequired();


            builder
                .HasOne(p => p.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.RoleId)
                .IsRequired();
        }
    }
}