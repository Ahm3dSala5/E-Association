using Domain.Entities.Securities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ConsumerTokenConfigurations : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
        {
            builder.HasKey(tu => new { tu.UserId, tu.LoginProvider, tu.Name });
            builder.HasOne<Consumer>()
                .WithMany(x => x.Tokens)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}
