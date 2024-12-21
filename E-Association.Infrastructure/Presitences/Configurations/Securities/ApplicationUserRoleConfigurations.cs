using Domain.Entities.Securities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ApplicationUserRoleConfigurations : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            // Composite primary key
            builder.HasKey(x => new { x.UserId, x.RoleId });

            // No direct navigation properties exist in IdentityUserRole<string>.
            // Configure relationships with ApplicationUser and ApplicationRole.
            builder.HasOne<ApplicationUser>()
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ApplicationRole>()
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
