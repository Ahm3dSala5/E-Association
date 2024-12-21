using Domain.Entities.Business;
using Domain.Entities.Securities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presitences.Configurations.Securities
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier").ValueGeneratedOnAdd();

            builder.HasMany(u => u.SubScriptions)
                .WithMany(s => s.Users)
                .UsingEntity<UserSubscriptions>(
                    join => join.HasOne(us => us.SubScription)
                                .WithMany(s => s.UserSubscriptions)
                                .HasForeignKey(us => us.SubscriptionId),
                    join => join.HasOne(us => us.User)
                                .WithMany(u => u.UserSubscriptions)
                                .HasForeignKey(us => us.UserId)
                );

            builder.HasOne(x => x.Balance)
                .WithOne(x => x.User)
                .HasForeignKey<ApplicationUser>(x => x.BalanceId)
                .IsRequired(false);
        }
    }
}
