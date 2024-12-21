using Domain.Entities.Securities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ApplicationUserLoginConfigurations : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });

            builder.HasOne<ApplicationUser>()
                .WithMany(x => x.Logins)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

        }
    }
}
